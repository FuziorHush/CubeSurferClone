using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

public class PlayerCubes : MonoBehaviour
{
    [SerializeField] private GameObject _cubePrefab = null;
    [SerializeField] private GameObject _cubeApperEffect = null;
    [SerializeField] private AudioClip _addCubesSound = null;
    [SerializeField] private AudioClip _looseCubesSound = null;

    private PlayerMoove _playerMoove;
    private PlayerSounds _playerSounds;

    [SerializeField] private int _maxCubes = 20;
    [SerializeField] private List<GameObject> _activeCubes = new List<GameObject>();//TODO: SerializeField For Debug
    public int NumCubes => _activeCubes.Count;

    [SerializeField] private ObjectPool _cubesPool;

    [SerializeField] private float _cubeHeightStep = 0.75f;

    private int _maxHit;
    private bool _immuneToObstacles;

    public float CurrentHeight => _currentHeight;
    private float _currentHeight;

    public UnityAction<int> CubeAdded;
    public UnityAction<int> CubeRemoved;
    public UnityAction OutOfCubes;

    private void Awake()
    {
        _playerMoove = GetComponent<PlayerMoove>();
        _playerSounds = GetComponent<PlayerSounds>();
    }

    private void Start()
    {
        _cubesPool.InitPool(_maxCubes + 10);
        AddCubes(1, false);
    }

    private void Update()
    {
        CheckDamage();
    }

    public void AddCubes(int numCubes, bool playSound = true)
    {
        for (int i = 0; i < numCubes; i++)
        {
            GameObject cube = _cubesPool.GetInactivePoolObject().gameObject;
            cube.transform.localPosition = new Vector3(0, _currentHeight, 0);
            cube.transform.localRotation = Quaternion.identity;
            _activeCubes.Add(cube);
            _currentHeight += _cubeHeightStep;
            Instantiate(_cubeApperEffect, cube.transform.position, cube.transform.rotation, cube.transform);

            CubeAdded?.Invoke(NumCubes);
        }
        if(playSound)
            _playerSounds.PlayOneInFrame(_addCubesSound);
    }

    public void StoreHit(int numCubes)//Если несколько коллайдеров одновременно сталкиваются с игроком, выбирается тот, который снимет больше всего
    {
        if (_immuneToObstacles)
            return;

        if (numCubes > _maxHit)
        {
            _maxHit = numCubes;
        }
    }

    public void RemoveCubes(int numCubes, bool unattach = true, bool playSound = true)
    {
        if (_activeCubes.Count == 0)
            return;

        if (numCubes > _activeCubes.Count)
            numCubes = _activeCubes.Count;

        _currentHeight -= _cubeHeightStep * numCubes;

        for (int i = 0; i < numCubes; i++)
        {
            GameObject cube = _activeCubes[0];
            _activeCubes.Remove(cube);

            if (unattach)
                cube.GetComponent<PoolElement>().UnattachAndReturnWithDelay(2);
            else
                cube.GetComponent<PoolElement>().ReturnIntoPool();

            CubeRemoved?.Invoke(NumCubes);
        }
        if (playSound)
            _playerSounds.PlayOneInFrame(_looseCubesSound);

        if (_activeCubes.Count == 0) {
            OutOfCubes?.Invoke();
        }
    }

    public void RemoveAllCubes() {
        RemoveCubes(_activeCubes.Count);
    }

    private void CheckDamage()//В начале нового кадра уничтожаются кубы, если _maxHit > 0
    {
        if (_immuneToObstacles)
            return;

        if (_maxHit > 0)
        {
            RemoveCubes(_maxHit);
            _maxHit = 0;

            StartCoroutine(ObstacleImmunity());
        }
    }

    private IEnumerator ObstacleImmunity() {
        _immuneToObstacles = true;
        yield return new WaitForSeconds(1 / _playerMoove.MooveSpeed + 0.1f);
        _immuneToObstacles = false;
    }
}

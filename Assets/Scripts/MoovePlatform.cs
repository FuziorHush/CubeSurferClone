using System.Collections;
using UnityEngine;
using DG.Tweening;

public class MoovePlatform : MonoBehaviour
{
    [SerializeField] private float _mooveSpeed = 5f;

    [SerializeField] private float _firstMooveTime;
    [SerializeField] private float _firstMooveSnap;
    [SerializeField] private float _secondMooveTime;
    [SerializeField] private float _secondMooveSnap;

    [SerializeField] private Transform _cubesContainer = null;

    private Transform[] _cubes;

    private void Start()
    {
        _cubes = new Transform[_cubesContainer.childCount];
        for (int i = 0; i < _cubesContainer.childCount; i++)
            _cubes[i] = _cubesContainer.GetChild(i);

        StartCoroutine(MooveCycle());
    }

    private IEnumerator MooveCycle()
    {
        for (int i = 0; i < _cubes.Length; i++)//goes to the first pos from the start pos
        {
            if(_cubes[i] != null)
            _cubes[i].DOLocalMove(new Vector3(_cubes[i].localPosition.x + _firstMooveSnap, 0f, 0f), _firstMooveTime);
        }
        yield return new WaitForSeconds(_firstMooveTime);

        while (true) //goen to the second pos, then to the first exc...
        {
            for (int i = 0; i < _cubes.Length; i++)
            {
                if (_cubes[i] != null)
                    _cubes[i].DOLocalMove(new Vector3(_cubes[i].localPosition.x + _secondMooveSnap, 0f, 0f), _secondMooveTime);
            }
            yield return new WaitForSeconds(_secondMooveTime);

            for (int i = 0; i < _cubes.Length; i++)
            {
                if (_cubes[i] != null)
                    _cubes[i].DOLocalMove(new Vector3(_cubes[i].localPosition.x - _secondMooveSnap, 0f, 0f), _secondMooveTime);
            }
            yield return new WaitForSeconds(_secondMooveTime);
        }
    }
}

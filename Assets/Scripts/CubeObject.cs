using System.Collections;
using UnityEngine;

public class CubeObject : MonoBehaviour
{
    [SerializeField] private GameObject _cubeModelPrefab = null;
    public int NumCubes = 1;

    [SerializeField] private float _cubeHeightStep = 0.75f;
    private float _currentHeight;

    private void OnValidate()//spawn new cubes on top of first in editor
    {
        if (NumCubes != transform.childCount)
        {
            if (NumCubes > 1)
            {
                PlaceCubesByAmount();
            }
            else
            {
                NumCubes = 1;
                PlaceCubesByAmount();
            }
        }
    }

    private void PlaceCubesByAmount()
    {
        for (int i = transform.childCount - 1; i > 0; i--)//destroy existing cubes
        {
            StartCoroutine(Destroy(transform.GetChild(i).gameObject));
        }

        _currentHeight = _cubeHeightStep * 1.5f;

        for (int i = 1; i < NumCubes; i++)//spawn new
        {
            GameObject cube = Instantiate(_cubeModelPrefab, transform);
            cube.transform.localPosition = new Vector3(0, _currentHeight, 0);
            _currentHeight += _cubeHeightStep;
        }
    }

    private IEnumerator Destroy(GameObject go)
    {
        yield return new WaitForEndOfFrame();
        DestroyImmediate(go);
    }
}

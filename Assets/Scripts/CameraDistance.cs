using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraDistance : MonoBehaviour
{
    [SerializeField] private PlayerCubes _playerCubes = null;

    [SerializeField] private float _distancingZ = -0.1f;
    [SerializeField] private float _distancingY = 0.1f;
    [SerializeField] private float _tranzitionSpeed = 2f;

    private void Update()
    {
        Vector3 newPos = new Vector3(0f, _distancingY * _playerCubes.NumCubes, _distancingZ * _playerCubes.NumCubes);
        transform.localPosition = Vector3.Lerp(transform.localPosition, newPos, Time.deltaTime * _tranzitionSpeed);
    }


}

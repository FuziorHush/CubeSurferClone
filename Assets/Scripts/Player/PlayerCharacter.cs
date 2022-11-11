using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerCharacter : MonoBehaviour
{
    private PlayerCubes _playerCubes;
    [SerializeField] private Transform _characterModel = null;
    [SerializeField] private float _characterMooveSpeed = 0.25f;
    [SerializeField] private float _cubeHeightStep = 0.75f;

    private void Awake()
    {
        _playerCubes = GetComponent<PlayerCubes>();
        _playerCubes.CubeAdded += MoovePlayer;
    }

    private void MoovePlayer() {
        _characterModel.Translate(new Vector3(0, _cubeHeightStep, 0));
    }
}
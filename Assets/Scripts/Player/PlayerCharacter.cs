using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerCharacter : MonoBehaviour
{
    private PlayerCubes _playerCubes;
    [SerializeField] private LayerMask _cubesLM = new LayerMask();
    [SerializeField] private Transform _characterModel = null;
    [SerializeField] private float _characterMooveSpeed = 0.25f;
    [SerializeField] private float _cubeHeightStep = 0.75f;

    [SerializeField] private Animator _animator = null;

    private void Awake()
    {
        _playerCubes = GetComponent<PlayerCubes>();
        _playerCubes.CubeAdded += MoovePlayer;

        Physics.IgnoreCollision(gameObject.GetComponent<Collider>(), _characterModel.GetComponent<Collider>(), true);
    }

    private void Update()
    {
        Collider[] colliders = Physics.OverlapSphere(transform.position, 0.1f, _cubesLM);
        if (colliders.Length > 0)
        {
            _animator.SetBool("Grounded", true);
        }
        else {
            _animator.SetBool("Grounded", false);
        }
    }

    private void MoovePlayer(int numCubes) {
        _characterModel.Translate(new Vector3(0, _cubeHeightStep, 0));
    }
}
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[RequireComponent(typeof(BoxCollider))]
public class PlayerCollider : MonoBehaviour
{
    private PlayerCubes _playerCubes;
    [SerializeField] private LayerMask _collectableCubeLayerMask;

    private void Awake()
    {
        _playerCubes = GetComponent<PlayerCubes>();
    }

    private void OnTriggerEnter(Collider other)
    {
        if (_collectableCubeLayerMask == (_collectableCubeLayerMask | (1 << other.gameObject.layer)))
        {
            ICubeObject collectableCube = other.GetComponent<ICubeObject>();
            if (collectableCube != null)
            {
                collectableCube.TouchedByPlayer(_playerCubes);
            }
        }
    }
}

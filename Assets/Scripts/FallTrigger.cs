using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

public class FallTrigger : MonoBehaviour
{
    [SerializeField] private LayerMask _playerLayer;

    public UnityAction CrossedByPlayer;

    private void OnTriggerEnter(Collider other)
    {
        if (_playerLayer == (_playerLayer | (1 << other.gameObject.layer)))
        {
            other.gameObject.GetComponent<PlayerMoove>().DeactivateMooving();
            other.gameObject.GetComponent<PlayerCubes>().RemoveAllCubes();
        }
    }
}

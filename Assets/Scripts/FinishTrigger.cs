using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

public class FinishTrigger : MonoBehaviour
{
    [SerializeField] private LayerMask _playerLayer;

    public UnityAction CrossedByPlayer;

    private void OnTriggerEnter(Collider other)
    {
        if (_playerLayer == (_playerLayer | (1 << other.gameObject.layer))) {
            other.GetComponent<PlayerMoove>().DeactivateMooving();
            CrossedByPlayer?.Invoke();
        }
    }
}

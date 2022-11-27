using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LavaBlock : MonoBehaviour
{
    [SerializeField] private float _cooldown;
    private float _currentCooldown;

    private void OnTriggerStay(Collider other)
    {
        if (_currentCooldown <= 0) {
            PlayerCubes playerCubes = other.GetComponent<PlayerCubes>();
            if (playerCubes != null) {
                playerCubes.RemoveCubes(1, false);
                _currentCooldown = _cooldown;
            }
        }
    }

    private void Update()
    {
        if (_currentCooldown > 0) {
            _currentCooldown -= Time.deltaTime;
        }
    }
}

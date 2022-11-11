using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TurnTrigger : MonoBehaviour
{
    [SerializeField] private TurnSide _turnSide;

    private void OnTriggerEnter(Collider other)
    {
        PlayerMoove playerMoove = other.GetComponent<PlayerMoove>();
        if (playerMoove != null) {
            playerMoove.Turn(_turnSide);
            Destroy(gameObject);
        }
    }
}

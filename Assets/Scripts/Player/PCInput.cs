using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[RequireComponent(typeof(PlayerMoove))]
public class PCInput : MonoBehaviour
{
    private PlayerMoove _playerMoove;

    private void Awake()
    {
        _playerMoove = GetComponent<PlayerMoove>();
    }

    private void FixedUpdate()
    {
        float horisontal = Input.GetAxis("Horizontal");
        _playerMoove.SetHorizontal(horisontal);
    }


}

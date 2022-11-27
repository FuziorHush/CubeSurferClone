using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using DG.Tweening;

public class PlayerMoove : MonoBehaviour
{
    private float _horizontalMoove;

    public float MooveSpeed {
        get => _mooveSpeed;
        set {
            value = Mathf.Clamp(value, 0f, 100f);
            _mooveSpeed = value;
            _actualMooveSpeed = _mooveSpeed / 50f; ;
        }
    }

    [SerializeField] private float _mooveSpeed;// meters/sec
    [SerializeField] private float _strafeSpeed;// meters/sec
    private float _actualMooveSpeed;// meters/FixedUpdate
    private float _actualStrafeSpeed;// meters/FixedUpdate

    private bool _canMoove = true;

    private void Start()
    {
        _actualMooveSpeed = _mooveSpeed / 50f;
        _actualStrafeSpeed = _strafeSpeed / 50f;

        GetComponent<PlayerCubes>().OutOfCubes += DeactivateMooving;
    }

    private void FixedUpdate()
    {
        if(_canMoove)
        transform.Translate(_horizontalMoove * _actualStrafeSpeed, 0f, _actualMooveSpeed);
    }

    public void SetHorizontal(float horizontal) {
        if (_canMoove)
            _horizontalMoove = horizontal;
    }

    public void Turn(TurnSide turnSide) {
        if (turnSide == TurnSide.Left)
            transform.DOBlendableLocalRotateBy(new Vector3(0f, -90f, 0f), 1f);
        else
            transform.DOBlendableLocalRotateBy(new Vector3(0f, 90f, 0f), 1f);
    }

    public void DeactivateMooving() {
        _canMoove = false;
    }
}

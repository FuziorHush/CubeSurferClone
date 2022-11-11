using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerMoove : MonoBehaviour
{
    [SerializeField] private Vector3 _mooveVector;

    public float MooveSpeed => _mooveSpeed;
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
        transform.Translate(_mooveVector * _actualMooveSpeed);
    }

    public void SetMoove(float horizontal) {
        if (_canMoove)
            transform.Translate(new Vector3(horizontal * _actualStrafeSpeed, 0,0));
    }

    public void Turn(TurnSide turnSide) {
        if (turnSide == TurnSide.Left)
        {
            StartCoroutine(RotateSmooth(-90f));
        }
        else {
            StartCoroutine(RotateSmooth(90f));
        }
    }

    public void DeactivateMooving() {
        _canMoove = false;
    }

    private IEnumerator RotateSmooth(float degree) {
        Quaternion target = Quaternion.Euler(0f, transform.eulerAngles.y + degree, 0f);
        while (true)
        {
            transform.rotation = Quaternion.RotateTowards(transform.rotation, target, 3f);
            yield return new WaitForFixedUpdate();
        }
    }
}

using UnityEngine;

public class ScreenInput : MonoBehaviour
{
    private PlayerMoove _playerMoove;

    [HideInInspector]public float ScreenHorizontal;

    [SerializeField] private float _speedModifier = 0.04f;
    [SerializeField] private float _maxHorizontalSpeed = 1.7f;

    private void Awake()
    {
        _playerMoove = GetComponent<PlayerMoove>();
    }

    private void FixedUpdate()
    {
        if (Input.touchCount == 1)
        {
            Touch touch = Input.GetTouch(0);

            if (touch.phase == TouchPhase.Moved)
            {
                ScreenHorizontal = Mathf.Clamp(touch.deltaPosition.x * _speedModifier, -_maxHorizontalSpeed, _maxHorizontalSpeed);
                _playerMoove.SetHorizontal(ScreenHorizontal);
            }
            else
            {
                ScreenHorizontal = 0f;
                _playerMoove.SetHorizontal(ScreenHorizontal);
            }
        }
        else {
            ScreenHorizontal = 0f;
            _playerMoove.SetHorizontal(ScreenHorizontal);
        }
    }
}

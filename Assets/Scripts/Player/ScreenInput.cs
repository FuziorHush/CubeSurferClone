using UnityEngine;

public class ScreenInput : MonoBehaviour
{
    private PlayerMoove _playerMoove;

    public float ScreenHorizontal;

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
                ScreenHorizontal = Mathf.Clamp(touch.deltaPosition.x * 0.04f, -1.7f, 1.7f);
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

using UnityEngine;
using UnityEngine.EventSystems;

public class ScreenInput : MonoBehaviour
{
    //IBeginDragHandler, IEndDragHandler, IDragHandler


    /* Vector2 _lastPosition = Vector2.zero;

 public Events.Vector2 OnSwipeStart = new Events.Vector2();
 public Events.Vector2 OnSwipeEnd = new Events.Vector2();
 public Events.Vector2 OnSwipe = new Events.Vector2();*/

    private PlayerMoove _playerMoove;

    public float ScreenHorizontal;

    private void Awake()
    {
        _playerMoove = GetComponent<PlayerMoove>();
    }
    /*

    public void OnBeginDrag(PointerEventData eventData)
    {
        _lastPosition = eventData.position;
        OnSwipeStart.Invoke(eventData.position);
    }

    public void OnEndDrag(PointerEventData eventData)
    {
        OnSwipeEnd.Invoke(eventData.position);
    }

    public void OnDrag(PointerEventData eventData)
    {
        Vector2 direction = eventData.position - _lastPosition;
        _lastPosition = eventData.position;
        Debug.Log(direction);

        _playerMoove.SetMoove(direction.x);

        OnSwipe.Invoke(direction);
    }*/

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

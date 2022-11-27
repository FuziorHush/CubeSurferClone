using System.Collections;
using System.Collections.Generic;
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

    private void Update()
    {
        if (Input.touchCount == 1) {
            Debug.Log("s");
            Touch touch = Input.GetTouch(0);

            if (touch.phase == TouchPhase.Moved) {
                _playerMoove.SetHorizontal(touch.deltaPosition.x);
            }
        }
    }
}

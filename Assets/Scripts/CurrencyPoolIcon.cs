using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using DG.Tweening;

public class CurrencyPoolIcon : MonoBehaviour
{
    public void StartAnimation(Vector3 startPos, Vector3 endPos, float time) {
        transform.position = startPos;
        Invoke("Deactivate", time);
        transform.DOMove(endPos, time);
    }

    private void Deactivate() {
        gameObject.SetActive(false);
    }
}

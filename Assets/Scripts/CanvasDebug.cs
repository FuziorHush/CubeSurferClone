using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class CanvasDebug : MonoBehaviour
{
    [SerializeField] private PlayerCubes PlayerCubes = null;

    [SerializeField] private Text HorizontalText = null;
    [SerializeField] private Text PlayerNumCubesText = null;

    private void Start()
    {
        if (PlayerCubes != null) {
            PlayerCubes.CubeAdded += UpdateNumCubesText;
            PlayerCubes.CubeRemoved += UpdateNumCubesText;
        }
    }

    void Update()
    {
        HorizontalText.text = Input.GetAxis("Horizontal").ToString();
    }

   private void UpdateNumCubesText() {
        PlayerNumCubesText.text = PlayerCubes.NumCubes.ToString();
    }
}

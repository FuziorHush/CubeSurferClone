using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class MainMenu : MonoBehaviour
{
    [SerializeField] private GameObject LevelButton = null;
    [SerializeField] private Transform LevelButtonsContainer = null;

    private void Start()
    {
        LevelUnlockData[] levelUnlocks = DataSystem.Instance.GetLevelsData();
        for (int i = 0; i < levelUnlocks.Length; i++)
        {
           Instantiate(LevelButton, LevelButtonsContainer).GetComponent<LevelButton>().SetData(levelUnlocks[i]);
        }
    }
}

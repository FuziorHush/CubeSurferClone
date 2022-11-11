using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class WinWindow : MonoBehaviour
{
    [SerializeField] private Button _nextLevelButton = null;
    [SerializeField] private Button _mainMenuButton = null;
    [SerializeField] private Text _prizeText = null;
    [SerializeField] private Image _prizeIcon = null;

    private int _sceneToLoad;

    public Transform CurrencyIconTransform => _prizeIcon.transform;

    private void Awake()
    {
        _nextLevelButton.onClick.AddListener(NextLevel);
        _mainMenuButton.onClick.AddListener(MainMenu);
    }

    public void OpenInit(int prize, int sceneToLoad) {
        _prizeText.text = prize.ToString();
        _sceneToLoad = sceneToLoad;
        DataSystem.Instance.AddCurrency(prize, CurrencyIconTransform);
    }

    private void NextLevel() {
        SceneManager.LoadScene(_sceneToLoad);
    }

    private void MainMenu()
    {

    }
}

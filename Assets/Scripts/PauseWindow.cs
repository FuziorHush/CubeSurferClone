using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class PauseWindow : MonoBehaviour
{
    [SerializeField] private Button _continueButton = null;
    [SerializeField] private Button _restartButton = null;
    [SerializeField] private Button _mainMenuButton = null;

    private int _sceneToLoad;

    private void Awake()
    {
        _continueButton.onClick.AddListener(Continue);
        _restartButton.onClick.AddListener(RestartLevel);
        _mainMenuButton.onClick.AddListener(MainMenu);
    }

    public void OpenInit(int sceneToLoad)
    {
        _sceneToLoad = sceneToLoad;
    }

    private void Continue()
    {
        WindowsSystem.Instance.CloseCurrentWindow();
    }

    private void RestartLevel()
    {
        SceneManager.LoadScene(_sceneToLoad);
    }

    private void MainMenu()
    {
        SceneManager.LoadScene(0);
    }
}

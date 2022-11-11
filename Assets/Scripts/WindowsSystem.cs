using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class WindowsSystem : MonoBehaviour
{
    public static WindowsSystem Instance;

    private GameObject _openedWindow;
    private bool _gamePaused = false;

    [SerializeField] private GameObject _pauseWindow = null;
    [SerializeField] private GameObject _winWindow = null;
    [SerializeField] private GameObject _looseWindow = null;

    private void Awake()
    {
        Instance = this;
    }

    public void CloseCurrentWindow()
    {
        _openedWindow.SetActive(false);
        _openedWindow = null;
        if (_gamePaused)
        {
            UnpauseGame();
        }
    }

    public void OpenPauseWindow()
    {
        if (_openedWindow == _pauseWindow)
            return;

        if (!_gamePaused)
            PauseGame();

        _openedWindow = _pauseWindow;
        _pauseWindow.SetActive(true);
        //PauseWindow.GetComponent<PauseWindow>().OpenInit();
    }

    public void OpenWinWindow(int prize, int sceneToLoad)
    {
        if (_openedWindow == _winWindow)
            return;

        _openedWindow = _winWindow;
        _winWindow.SetActive(true);
        _winWindow.GetComponent<WinWindow>().OpenInit(prize, sceneToLoad);
    }

    public void OpenLooseWindow()
    {
        if (_openedWindow == _looseWindow)
            return;

        if (!_gamePaused)
            PauseGame();

        _openedWindow = _looseWindow;
        _looseWindow.SetActive(true);
        //LooseWindow.GetComponent<LooseWindow>().OpenInit();
    }

    public void PauseGame()
    {
        _gamePaused = true;
        Time.timeScale = 0f;
        Cursor.lockState = CursorLockMode.None;
        Cursor.visible = true;
    }

    public void UnpauseGame()
    {
        _gamePaused = false;
        Time.timeScale = 1f;
        Cursor.lockState = CursorLockMode.Locked;
        Cursor.visible = false;
    }
}

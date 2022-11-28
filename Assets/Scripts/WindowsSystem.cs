using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using DG.Tweening;

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

    private void Update()
    {
        if (Input.GetKeyDown(KeyCode.Escape))
            OpenPauseWindow();
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
        if (_openedWindow != null)
            return;

        if (!_gamePaused)
            PauseGame();

        _openedWindow = _pauseWindow;
        _pauseWindow.SetActive(true);
        _pauseWindow.GetComponent<RectTransform>().DOAnchorPos(new Vector3(0f, -1600f), 0.5f).SetEase(Ease.InOutQuint).SetUpdate(true).From();
        _pauseWindow.GetComponent<PauseWindow>().OpenInit(DataSystem.Instance.CurrentLevel+1);
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

        _openedWindow = _looseWindow;
        _looseWindow.SetActive(true);
        _looseWindow.GetComponent<LooseWindow>().OpenInit(DataSystem.Instance.CurrentLevel+1);
    }

    public void PauseGame()
    {
        _gamePaused = true;
        Time.timeScale = 0f;
       // Cursor.lockState = CursorLockMode.None;
       // Cursor.visible = true;
    }

    public void UnpauseGame()
    {
        _gamePaused = false;
        Time.timeScale = 1f;
       // Cursor.lockState = CursorLockMode.Locked;
       // Cursor.visible = false;
    }
}

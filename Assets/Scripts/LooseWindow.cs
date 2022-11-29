using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class LooseWindow : MonoBehaviour
{
    [SerializeField] private Button _tryAgainButton = null;
    [SerializeField] private Button _mainMenuButton = null;

    private int _sceneToLoad;

    private void Awake()
    {
        _tryAgainButton.onClick.AddListener(TryAgain);
        _mainMenuButton.onClick.AddListener(MainMenu);
    }

    public void OpenInit(int sceneToLoad)
    {
        _sceneToLoad = sceneToLoad;
    }

    private void TryAgain()
    {
        WindowsSystem.Instance.CloseCurrentWindow();
        SceneManager.LoadScene(_sceneToLoad);
    }

    private void MainMenu()
    {
        WindowsSystem.Instance.CloseCurrentWindow();
        SceneManager.LoadScene(0);
    }
}

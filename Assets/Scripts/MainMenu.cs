using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class MainMenu : MonoBehaviour
{
    [SerializeField] private GameObject LevelButton = null;
    [SerializeField] private Transform LevelButtonsContainer = null;
    [SerializeField] private Text _currencyText = null;

    private void Start()
    {
        CreateLevelButtons();

        _currencyText.text = DataSystem.Instance.CurrentCurrency.ToString();
    }

    private void Update()
    {
        if (Input.GetKeyDown(KeyCode.Escape))
            Application.Quit();
    }

    private void CreateLevelButtons()
    {
        LevelUnlockData[] levelUnlocks = DataSystem.Instance.GetLevelsData();

        for (int i = 0; i < levelUnlocks.Length; i++)
        {
            LevelButton levelButton = Instantiate(LevelButton, LevelButtonsContainer).GetComponent<LevelButton>();
            levelButton.SetData(levelUnlocks[i]);

            int id = i;
            if(levelUnlocks[i].Unlocked)
            levelButton.Button.onClick.AddListener(delegate { LoadLevel(id); });
        }
    }

    private void LoadLevel(int level) {
        SceneManager.LoadScene(level + 1);
    }
}

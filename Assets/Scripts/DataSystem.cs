using UnityEngine;
using UnityEngine.Events;

public class DataSystem : MonoBehaviour
{
    public static DataSystem Instance;

    private int _numLevels = 6;

    private GameSave _save;//save loads when the game starts and existing all time

    private bool _saveLoaded;
    public bool SaveLoaded => _saveLoaded;

    [SerializeField] private bool _remakeSaveFile;

    public int CurrentLevel => _save.CurrentLevel;
    public int CurrentCurrency => _save.Currency;

    public UnityAction<GameSave> SaveFileLoaded;
    public UnityAction<int> LevelChanged;
    public UnityAction<int, int, Transform> CurrencyAdded;

    public void Init()
    {
        if (Instance == null)
            Instance = this;

#if UNITY_EDITOR
        if (_remakeSaveFile)
            CreateDefaultGameSave();
#endif

        LoadGame();
    }

    public int IncreaceLevel()
    {
        if (_save.CurrentLevel == _numLevels - 1)
        {
            _save.CurrentLevel = 2;
        }
        else
        {
            _save.CurrentLevel++;
            _save.LevelsUnlockData[CurrentLevel].Unlocked = true;
        }

        return _save.CurrentLevel;
    }

    public void AddCurrency(int added, Transform currencyAnimStartPosition = null) {
        _save.Currency += added;
        CurrencyAdded?.Invoke(CurrentCurrency, added, currencyAnimStartPosition);
    }

    /// <summary>
    /// Генерирует новый файл сохранения игры
    /// </summary>
    public void CreateDefaultGameSave()
    {
        _save = new GameSave();

        LevelUnlockData[] levelsUnlockData = new LevelUnlockData[_numLevels];
        for (int i = 0; i < levelsUnlockData.Length; i++) {
            levelsUnlockData[i].LevelNumber = i;
            levelsUnlockData[i].Unlocked = false;
        }

        levelsUnlockData[0].Unlocked = true;

        _save.LevelsUnlockData = levelsUnlockData;
        _save.CurrentLevel = 0;
        _save.Currency = 0;

        SaveFileOperator.SaveGame(_save);
    }

    public void SaveGame()
    {
        SaveFileOperator.SaveGame(_save);
    }

    public void LoadGame()
    {
        _save = (GameSave)SaveFileOperator.LoadGame();
        if (_save != null)
        {
            _saveLoaded = true;
            SaveFileLoaded?.Invoke(_save);
        }
    }

    public LevelUnlockData[] GetLevelsData() {
        return (LevelUnlockData[])_save.LevelsUnlockData.Clone();
    }

    private void OnLevelWasLoaded(int level)
    {
        if(level != 0)
        _save.CurrentLevel = level - 1;
    }
}

[System.Serializable]
public class GameSave : IGameSave
{
    public LevelUnlockData[] LevelsUnlockData;
    public int CurrentLevel;
    public int Currency;
}

[System.Serializable]
public struct LevelUnlockData {
    public int LevelNumber;
    public bool Unlocked;
}

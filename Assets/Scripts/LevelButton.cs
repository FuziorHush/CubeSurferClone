using UnityEngine;
using UnityEngine.UI;

public class LevelButton : MonoBehaviour
{
    [SerializeField] private Text _levelNum = null;
    [SerializeField] private GameObject _lockIcon = null;

    public void SetData(LevelUnlockData data) {
        _levelNum.text = (data.LevelNumber + 1).ToString();
        _lockIcon.SetActive(!data.Unlocked);
    }
}

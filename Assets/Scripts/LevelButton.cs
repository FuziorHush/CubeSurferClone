using UnityEngine;
using UnityEngine.UI;

[RequireComponent(typeof(Button))]
public class LevelButton : MonoBehaviour
{
    [SerializeField] private Text _levelNum = null;
    [SerializeField] private GameObject _lockIcon = null;

    public Button Button => GetComponent<Button>();

    public void SetData(LevelUnlockData data) {
        _levelNum.text = (data.LevelNumber + 1).ToString();
        _lockIcon.SetActive(!data.Unlocked);
    }
}

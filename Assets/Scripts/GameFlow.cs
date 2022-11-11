using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameFlow : MonoBehaviour
{
    [SerializeField] private PlayerCubes _playerCubes = null;
    [SerializeField] private FinishTrigger _finishTrigger = null;

    [SerializeField] private int _currencyForWin = 0;

    private void Start()
    {
        if (_playerCubes != null) 
            _playerCubes.OutOfCubes += LevelLoose;

        if (_finishTrigger != null)
            _finishTrigger.CrossedByPlayer += LevelWin;
    }

    private void LevelWin()
    {
        int level = DataSystem.Instance.IncreaceLevel();
        WindowsSystem.Instance.OpenWinWindow(_currencyForWin, level);
        DataSystem.Instance.SaveGame();
    }

    private void LevelLoose()
    {
        StartCoroutine(LooseTimer());
    }

    private IEnumerator LooseTimer() {
        yield return new WaitForSeconds(2f);
        WindowsSystem.Instance.OpenLooseWindow();
    }
}

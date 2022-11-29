using System.Collections;
using UnityEngine;

public class GameFlow : MonoBehaviour
{
    [SerializeField] private PlayerCubes _playerCubes = null;
    [SerializeField] private FinishTrigger _finishTrigger = null;

    [SerializeField] private int _currencyForWin = 0;

    [SerializeField] private PlayerMoove _playerMoove = null;
    [SerializeField] private float _setPlayerSpeed = 0;//if 0 does not set

    private void Start()
    {
        if (_playerCubes != null) 
            _playerCubes.OutOfCubes += LevelLoose;

        if (_finishTrigger != null)
            _finishTrigger.CrossedByPlayer += LevelWin;

        if (_playerMoove != null) {
            if (_setPlayerSpeed != 0) {
                _playerMoove.MooveSpeed = _setPlayerSpeed;
            }
        }

        UISystem.Instance.ActivateUI();//enable UI if disabled in the inspector
    }

    private void LevelWin()
    {
        int level = DataSystem.Instance.IncreaceLevel();
        WindowsSystem.Instance.OpenWinWindow(_currencyForWin, level+1);
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

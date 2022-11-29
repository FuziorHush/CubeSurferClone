using UnityEngine;
using UnityEngine.UI;

public class CanvasDebug : MonoBehaviour
{
    [SerializeField] private GameObject Player = null;

    private PlayerCubes _playerCubes;
    private PlayerMoove _playerMoove;
    private ScreenInput _screenInput;

    [SerializeField] private Text ScreenHorizontalText = null;
    [SerializeField] private Text PlayerHorizontalText = null;
    [SerializeField] private Text PlayerNumCubesText = null;

    private void Start()
    {
        _playerCubes = Player.GetComponent<PlayerCubes>();
        if (_playerCubes != null) {
            _playerCubes.CubeAdded += UpdateNumCubesText;
            _playerCubes.CubeRemoved += UpdateNumCubesText;
        }

        _playerMoove = Player.GetComponent<PlayerMoove>();
        _screenInput = Player.GetComponent<ScreenInput>();

    }

    void Update()
    {
        if (_playerMoove != null)
            PlayerHorizontalText.text = _playerMoove.HorizontalMoove.ToString();

        if (_screenInput != null)
            ScreenHorizontalText.text = _screenInput.ScreenHorizontal.ToString();
    }

   private void UpdateNumCubesText(int numCubes) {
        PlayerNumCubesText.text = numCubes.ToString();
    }
}

using System.Collections;
using UnityEngine;
using UnityEngine.UI;
using DG.Tweening;

public class UISystem : MonoBehaviour
{
    [SerializeField] private Button _pauseButton = null;
    [SerializeField] private CanvasGroup _currency = null;
    [SerializeField] private Text _currencyText = null;

    [SerializeField] private RectTransform _currencyAnimEndPosition = null;

    [SerializeField] private ObjectPool _currencyIconPool = null;

    private Transform _currencyAnimStartPosition;

    private void Start()
    {
        _currency.alpha = 0;
        _currencyIconPool.InitPool(100);

        _pauseButton.onClick.AddListener(PauseButtonPressed);

        if (DataSystem.Instance != null)
            DataSystem.Instance.CurrencyAdded += DrawCurrency;
    }

    public void DrawCurrency(int currentCurrency, int added, Transform animStartPosition = null)
    {
        if (_currencyIconPool != null && animStartPosition != null)
        {
            _currencyAnimStartPosition = animStartPosition;
            StartCoroutine(AddCurrencyAnimation(added));
        }

        ShowCurrencyGroup(currentCurrency, added);
    }

    private IEnumerator AddCurrencyAnimation(int amount)
    {
        PoolElement element;
        int icons = Mathf.Clamp(amount / 10, 0, _currencyIconPool.MaxCapacity);
        for (int i = 0; i < icons; i++)
        {
            _currencyIconPool.TryGetObject(out element);
            element.GetComponent<CurrencyPoolIcon>().StartAnimation(_currencyAnimStartPosition.position, _currencyAnimEndPosition.position, 1f);
            yield return new WaitForSeconds(0.05f);
        }
    }

    private void ShowCurrencyGroup(int currentCurrency, int added)
    {
        float time = (added / 10) * 0.05f;

        _currencyText.text = currentCurrency.ToString();

        Sequence seq = DOTween.Sequence();
        seq.Append(_currency.DOFade(1f, 0.75f));
        seq.AppendInterval(time);
        seq.Append(_currency.DOFade(0f, 0.75f));
    }

    private void PauseButtonPressed()
    {
        WindowsSystem.Instance.OpenPauseWindow();
    }
}

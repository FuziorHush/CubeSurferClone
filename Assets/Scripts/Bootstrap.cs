using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Bootstrap : MonoBehaviour
{
    private static bool _inited;

    [SerializeField] private GameObject _dataSystem = null;
    [SerializeField] private GameObject _canvasPlayer = null;
    [SerializeField] private GameObject _eventSystem = null;

    private void Awake()
    {
        if (_inited)
            return;

        DataSystem dataSystem = Instantiate(_dataSystem).GetComponent<DataSystem>();
        UISystem UISystem = Instantiate(_canvasPlayer).GetComponent<UISystem>();
        GameObject eventSystem = Instantiate(_eventSystem);

        dataSystem.Init();
        UISystem.Init();

        DontDestroyOnLoad(dataSystem.gameObject);
        DontDestroyOnLoad(UISystem.gameObject);
        DontDestroyOnLoad(eventSystem);

        _inited = true;
    }
}

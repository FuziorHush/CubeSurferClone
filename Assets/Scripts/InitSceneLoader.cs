using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class InitSceneLoader : MonoBehaviour
{
    void Start()
    {
        SceneManager.LoadScene(DataSystem.Instance.CurrentLevel+1);
    }
}

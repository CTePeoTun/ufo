using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class SceneLoader : MonoBehaviour
{
    public static void Open(SceneName sceneName)
    {
        SceneManager.LoadScene(Enum.GetName(typeof(SceneName), sceneName));
    }

    public static SceneName LoadingScene;
    public static void OpenViaLoadingScreen(SceneName sceneName)
    {
        if (sceneName != SceneName.Loading)
        {
            LoadingScene = sceneName;
            SceneManager.LoadScene(Enum.GetName(typeof(SceneName), SceneName.Loading));
        } else
        {
            Debug.LogWarning("Trying to open the loading scene via the loading scene. Aborted!");
        }        
    }

}

using UnityEngine;
using UnityEngine.UI;

public class SceneOpener : MonoBehaviour
{
    [SerializeField] private SceneName sceneName;

    public void Open()
    {
        SceneLoader.Open(sceneName);
    }

    public void OpenViaLoadingScreen()
    {
        SceneLoader.OpenViaLoadingScreen(sceneName);
    }
}

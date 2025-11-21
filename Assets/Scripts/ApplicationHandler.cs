using System.Collections;
using System.Collections.Generic;
using System.Diagnostics;
using UnityEngine;
using UnityEngine.SceneManagement;

// This component can be used to access methods for changing the scene, and quitting the game
// It can be used together with UnityEventOnTrigger, or UI-button-events, to decide when a scene should be changed or the game should be closed
public class ApplicationHandler : MonoBehaviour
{
    public string sceneToLoad = "Level_1";

    public void ChangeScene()
    {
        UnityEngine.Debug.Log("Loading: " + sceneToLoad);
        // Load the scene named "Level_1"
        SceneManager.LoadSceneAsync(sceneToLoad, LoadSceneMode.Single);
    }

    public void QuitGame()
    {
        Application.Quit();
    }
}

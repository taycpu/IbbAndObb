using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class StartSceneHandler : MonoBehaviour
{
    [SerializeField] private GameObject loadingScreen;
    [SerializeField] private Image loadingBar;


    public void LoadMainScene()
    {
        loadingScreen.gameObject.SetActive(true);
        StartCoroutine(LoadYourAsyncScene());
    }

    public void QuitGame()
    {
        Application.Quit();
    }

    IEnumerator LoadYourAsyncScene()
    {
        // The Application loads the Scene in the background as the current Scene runs.
        // This is particularly good for creating loading screens.
        // You could also load the Scene by using sceneBuildIndex. In this case Scene2 has
        // a sceneBuildIndex of 1 as shown in Build Settings.

        AsyncOperation asyncLoad = SceneManager.LoadSceneAsync(1);

        // Wait until the asynchronous scene fully loads
        while (!asyncLoad.isDone)
        {
            loadingBar.fillAmount = asyncLoad.progress;
            yield return null;
        }
    }
}
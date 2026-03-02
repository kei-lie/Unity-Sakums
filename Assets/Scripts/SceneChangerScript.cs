using System.Collections;
using UnityEngine;
using UnityEngine.SceneManagement;

public class SceneChangerScript : MonoBehaviour
{
    public void LoadWithDelay(string sceneName)
    {
        StartCoroutine(LoadSceneAfterDelay(sceneName));
    }

    private IEnumerator LoadSceneAfterDelay(string sceneName)
    {
        yield return new WaitForSecondsRealtime(1.5f); // ✅ works even if timeScale = 0

        Time.timeScale = 1f; // ✅ always reset time before loading
        SceneManager.LoadScene(sceneName, LoadSceneMode.Single);
    }

    public void QuitApplication()
    {
        Application.Quit();
    }
}
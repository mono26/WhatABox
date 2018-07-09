using UnityEngine;
using UnityEngine.SceneManagement;
using System.Collections;

public class EndOfLevel : MonoBehaviour
{
    public string menuSceneName = "MainMenu";
    public string nextLevel = "Level02";
    public int levelToUnlock = 2;

    public float restartSlowness = 10f;

    public SceneFader sceneFader;

    public void Retry()
    {
        StartCoroutine(RestartLevel());
    }
    IEnumerator RestartLevel()
    {
        Time.timeScale = 1f / restartSlowness;
        Time.fixedDeltaTime = Time.fixedDeltaTime / restartSlowness;

        yield return new WaitForSeconds(1f / restartSlowness);

        Time.timeScale = 1f;
        Time.fixedDeltaTime = Time.fixedDeltaTime * restartSlowness;

        sceneFader.FadeTo(SceneManager.GetActiveScene().name);
    }
    public void Menu()
    {
        sceneFader.FadeTo(menuSceneName);
    }
    public void Continue()
    {
        PlayerPrefs.SetInt("levelReached", levelToUnlock);
        sceneFader.FadeTo(nextLevel);
    }
}

using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

/// <summary>
/// Responsible for Levels
/// </summary>
public class LevelLoader : MonoBehaviour
{
    [SerializeField] int timeToWait = 4;
    int currentSceneIndex;
    // Start is called before the first frame update
    void Start()
    {
        currentSceneIndex = SceneManager.GetActiveScene().buildIndex;
        if (currentSceneIndex == 0)
        {
            StartCoroutine(WaitForTime());
        }
    }

    /// <summary>
    /// Waits for timeToWait seconds and then loads next scene
    /// </summary>
    /// <returns></returns>
    private IEnumerator WaitForTime()
    {
        yield return new WaitForSeconds(timeToWait);
        LoadNextScene();
    }

    public void RestartScene()
    {
        Time.timeScale = 1;
        SceneManager.LoadScene(currentSceneIndex);
    }

    public void LoadMainMenu()
    {
        Time.timeScale = 1;
        SceneManager.LoadScene("Start Screen");
    }

    /// <summary>
    /// Loads next scene - check build settings
    /// </summary>
    public void LoadNextScene()
    {
        SceneManager.LoadScene(currentSceneIndex + 1);
    }

    /// <summary>
    /// Shows Score board scene
    /// </summary>
    public void ShowScoreBoard()
    {
        SceneManager.LoadScene("Score Board");
    }
    /// <summary>
    /// Propts for nickname after game is finished
    /// </summary>
    public void ShowScoreBoardAndPromptNickName()
    {
        SceneManager.LoadScene("Score Board Prompt");
    }

    /// <summary>
    /// Quits Game
    /// </summary>
    public void QuitGame()
    {
        Application.Quit();
    }

}

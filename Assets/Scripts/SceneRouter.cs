using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class SceneRouter : MonoBehaviour
{

    public void GotoBackgroundScene()
    {
        SceneManager.LoadScene("BackgroundScene");
        Time.timeScale = 1f;
    }

    public void GotoMainScene()
    {
        SceneManager.LoadScene("MainScene");
        Time.timeScale = 1f;
    }

    public void RestartScene()
    {
        SceneManager.LoadScene(SceneManager.GetActiveScene().name);
        Time.timeScale = 1f;

    }
}
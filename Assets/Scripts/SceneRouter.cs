using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class SceneRouter : MonoBehaviour
{
    public GameObject bulletDmg;
    public void GotoBackgroundScene()
    {
        SceneManager.LoadScene("BackgroundScene");
        Time.timeScale = 1f;
        bulletDmg.GetComponent<PlayerBullet>().dmg = 3;
    }

    public void GotoMainScene()
    {
        DataManager.I.CurrentScore = 0;
        SceneManager.LoadScene("MainScene");
        Time.timeScale = 1f;
    }

    public void RestartScene()
    {
        DataManager.I.CurrentScore = 0;
        bulletDmg.GetComponent<PlayerBullet>().dmg = 3;
        SceneManager.LoadScene(SceneManager.GetActiveScene().name);
        Time.timeScale = 1f;

    }
}
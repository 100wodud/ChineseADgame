using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;

public class UIPanel : MonoBehaviour
{
    private float GameSpeed = 1f;
    private bool sound = true;
    public AudioSource bgmSource;

    public GameObject Play;
    public GameObject Pause;
    public GameObject Mute;
    public GameObject Loud;


    public GameObject Passive;

    public void GamePause()
    {
        if(GameSpeed > 0f)
        {
            GameSpeed = 0f;
            Time.timeScale = 0f;
            Pause.SetActive(false);
            Play.SetActive(true);
        } else
        {
            GameSpeed = 1f;
            Time.timeScale = 1f;
            Pause.SetActive(true);
            Play.SetActive(false);
        }
    }

    public void GameMute()
    {
        if (sound)
        {
            sound = false;
            bgmSource.Pause();
            Mute.SetActive(false);
            Loud.SetActive(true);
        } else
        {
            sound = true;
            bgmSource.Play();
            Mute.SetActive(true);
            Loud.SetActive(false);
        }
    }

    //test
    public void TestFunction()
    {
        Instantiate(Passive);
        Time.timeScale = 0f;
    }
}

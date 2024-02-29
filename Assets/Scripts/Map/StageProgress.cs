using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class StageProgress : MonoBehaviour
{
    [SerializeField] Slider slider = null;

    private float tLoading = 10;
    private float tCurrent;
    private float tStart;

    private int time_Spawn = 0;



    // Start is called before the first frame update
    void Start()
    {
        tCurrent = tLoading;
        tStart = Time.time;
        FillAmount(0);
    }

    // Update is called once per frame
    void Update()
    {
        Loading();
    }
    private void Loading()
    {
        tCurrent = (Time.time - tStart) / 5.0f;
        if (tCurrent < tLoading)
        {
            FillAmount(tCurrent / tLoading);
        }
        else
        {
            FillAmount(1);
            Time.timeScale = 0f;
        }
    }
    private void FillAmount(float _value)
    {
        slider.value = _value;
    }
}

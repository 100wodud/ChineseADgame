using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class StageProgress : MonoBehaviour
{
    [SerializeField] Slider slider = null;

    public GameObject test;

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
        if (time_Spawn < (int)(tCurrent / tLoading * 5f))
        {
            float randX = Random.Range(-4, 4);
            GameObject tests = Instantiate(test);
            tests.transform.position = new Vector3(randX, 10, 0);
            time_Spawn = (int)(tCurrent / tLoading * 5f);
        } 

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
            Debug.Log("보스등장");
            Time.timeScale = 0f;
        }
    }
    private void FillAmount(float _value)
    {
        slider.value = _value;
    }
}

using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class StageProgress : MonoBehaviour
{
    [SerializeField] Slider slider = null;

    public GameObject test;

    private float time_loading = 10;
    private float time_current;
    private float time_start;

    private int time_Spawn = 0;



    // Start is called before the first frame update
    void Start()
    {
        time_current = time_loading;
        time_start = Time.time;
        FillAmount(0);
    }

    // Update is called once per frame
    void Update()
    {
        Check_Loading();
        if (time_Spawn < (int)(time_current / time_loading * 5f))
        {
            float randX = Random.Range(-4, 4);
            GameObject tests = Instantiate(test);
            tests.transform.position = new Vector3(randX, 10, 0);
            time_Spawn = (int)(time_current / time_loading * 5f);
        } else
        {
            FillAmount(1);
            Debug.Log("보스등장");
        }

    }
    private void Check_Loading()
    {
        time_current = (Time.time - time_start) / 5.0f;
        if (time_current < time_loading)
        {
            FillAmount(time_current / time_loading);
        }
    }
    private void FillAmount(float _value)
    {
        slider.value = _value;
    }
}

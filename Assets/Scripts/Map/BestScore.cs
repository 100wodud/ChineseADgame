using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class BestScore : MonoBehaviour
{
    public GameObject bestRecord;
    public TextMeshProUGUI record;

    // Start is called before the first frame update
    void Start()
    {
        record.text = GameManager.I.Score.ToString("N1");
        if (GameManager.I.Score > DataManager.I.bestScore)
        {
            DataManager.I.bestScore = GameManager.I.Score;
            bestRecord.SetActive(true);
        }
        else
        {
            bestRecord.SetActive(false);

        }
    }
}

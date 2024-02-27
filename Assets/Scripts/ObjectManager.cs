using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ObjectManager : MonoBehaviour
{
    public GameObject WallTPrefab;
    public GameObject WallBPrefab;

    GameObject[] WallT;
    GameObject[] WallB;

    GameObject[] targetPool;

    /*
    void Awake()
    {
        WallT = new GameObject[10];
        WallB = new GameObject[10];

        Generate();
    }
    void Generate()
    {
        for (int i = 0; i < WallB.Length; i++)
        {
            WallB[i] = Instantiate(WallBPrefab);
            WallB[i].SetActive(false);
        }
        for (int i = 0; i < WallT.Length; i++)
        {
            WallT[i] = Instantiate(WallTPrefab);
            WallT[i].SetActive(false);
        }
    }
    */

    public GameObject MakeObj(string type)
    {
        switch (type)
        {
            case "WallT":
                targetPool = WallT;
                break;
            case "WallB":
                targetPool = WallB;
                break;
        }

        for (int i = 0; i < targetPool.Length; i++)
        {
            if (!targetPool[i].activeSelf)
            {
                targetPool[i].SetActive(true);
                return targetPool[i];
            }
        }

        return null;
    }
}
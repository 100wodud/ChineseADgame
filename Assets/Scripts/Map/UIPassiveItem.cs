using System.Collections;
using System.Collections.Generic;
using System.Runtime.Serialization;
using UnityEngine;
using UnityEngine.EventSystems;

public class UIPassiveItem : MonoBehaviour
{
    public GameObject[] items;
    public GameObject panel;

    public Transform[] spawnPoints;

    // Start is called before the first frame update
    void Start()
    {
        SpawnPassiveItems();
    }

    void SpawnPassiveItems()
    {
        GameObject[] array = ShuffleArray(items);
        GameObject obj;
        int i = 0;
        while(i < 3)
        {
            obj = Instantiate(array[i], spawnPoints[i].position, spawnPoints[i].rotation);
            obj.transform.SetParent(panel.transform, false);
            obj.transform.position = spawnPoints[i].position;
            i++;
        }
    }
    private T[] ShuffleArray<T>(T[] array)
    {
        int random1, random2;
        T temp;

        for (int i = 0; i < array.Length; ++i)
        {
            random1 = Random.Range(0, array.Length);
            random2 = Random.Range(0, array.Length);

            temp = array[random1];
            array[random1] = array[random2];
            array[random2] = temp;
        }

        return array;
    }

    public void ClickButton()
    {
        GameObject clickObject = EventSystem.current.currentSelectedGameObject;

        Debug.Log(clickObject.name);
    }
}

using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DataManager : MonoBehaviour
{
    public static DataManager I;
    public float bestScore;

    public int level = 1;


    void Awake()
    {
        if (I != null) //�̹� �����ϸ�
        {
            Destroy(gameObject); //�ΰ� �̻��̴� ����
            return;
        }
        I = this;
        DontDestroyOnLoad(this.gameObject);

    }

    public void StageLevelup()
    {
        Debug.Log("Ŭ����");
        level++;
    }
}

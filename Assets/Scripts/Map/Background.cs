using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Background : MonoBehaviour
{
    public float speed;
    public int startIndex;
    public int endIndex;
    public Transform[] sprites;

    float viewHeigjt;

    private void Awake()
    {
        viewHeigjt = Camera.main.orthographicSize* 2.0f;
    }

    void Update()
    {
        Vector3 curPos = transform.position;
        Vector3 nextPos = Vector3.down * speed * Time.deltaTime;
        transform.position = curPos + nextPos;

        if (sprites[endIndex].position.y < viewHeigjt * -1)
        {
            Vector3 backSpritePos = sprites[startIndex].localPosition;
            Vector3 frontSpritePos = sprites[endIndex].localPosition;
            sprites[endIndex].transform.localPosition = backSpritePos + Vector3.up * viewHeigjt;

            int StartIndexSave = startIndex;
            startIndex = endIndex;
            endIndex = (StartIndexSave - 1 == -1 ? sprites.Length-1 : StartIndexSave-1);
        }
    }
}

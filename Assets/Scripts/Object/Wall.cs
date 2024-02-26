using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Wall : MonoBehaviour
{
    public GameObject Gameover;
    private void Update()
    {

        Vector3 curPos = transform.position;
        Vector3 nextPos = Vector3.down * 3 * Time.deltaTime;
        transform.position = curPos + nextPos;
        if(transform.position.y < -25f)
        {
            gameObject.SetActive(false);
        }
    }

    void OnTriggerEnter2D(Collider2D collision)
    {
        if(collision.gameObject.tag == "Player")
        {
            Destroy(collision.gameObject);
            Time.timeScale = 0f;
            Instantiate(Gameover);
        }
    }
}

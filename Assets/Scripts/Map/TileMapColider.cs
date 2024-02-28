using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TileMapColider : MonoBehaviour
{
    public GameObject Gameover;
    void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.tag == "Player")
        {
        }

        if(collision.gameObject.tag == "EnemyBullet")
        {
            Destroy(collision.gameObject);
        }
        if (collision.gameObject.tag == "Enemy")
        {
            Destroy(collision.gameObject);
        }
    }
}

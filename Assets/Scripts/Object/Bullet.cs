using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Bullet : MonoBehaviour
{
    public GameObject Gameover;
    public float bulletSpeed;
    public int dmg;
    private void Update()
    {
        Vector3 curPos = transform.position;
        Vector3 nextPos = Vector3.left * bulletSpeed * Time.deltaTime;
        transform.position = curPos + nextPos;
        if (transform.position.x < -20f)
        {
            gameObject.SetActive(false);
        }
    }
    void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.tag == "Player")
        {
            Destroy(collision.gameObject);
            Time.timeScale = 0f;
            Instantiate(Gameover);
        }
    }
}

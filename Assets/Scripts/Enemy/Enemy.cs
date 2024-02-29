using System;
using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class Enemy : MonoBehaviour
{
    public string enemyName;
    public float speed;
    public float power;
    public int health;
    public Sprite[] sprites;

    public float maxShotDelay;
    public float curShotDelay;

    public GameObject bulletObjA;
    public GameObject bulletObjB;
    public GameObject player;
    public ObjectManager objectManager;
   
    SpriteRenderer spriteRenderer;
    Rigidbody2D rigid;
    [SerializeField] private List<CharacterStats> statsModifier;


    [SerializeField] private TextMeshPro CurrentHpTxt;
    private void Awake()
    {
        spriteRenderer = GetComponent<SpriteRenderer>();
        rigid = GetComponent<Rigidbody2D>();
        rigid.velocity = Vector2.down * speed;
    }

    private void OnEnable()
    {
        switch (enemyName)
        {
            case "EnemyL":
                health = 40;
                break;
            case "EnemyM":
                health = 10;
                break;
            case "EnemyS":
                health = 3;
                break;

        }
    }

    private void Update()
    {
        Fire();
        Reload();
    }

    void Reload()
    {
        curShotDelay += Time.deltaTime;
    }

    void Fire()
    {
        if (curShotDelay < maxShotDelay)
            return;

        if (enemyName == "EnemyS")
        {
            GameObject bullet = objectManager.MakeObj("BulletEnemyA");
            bullet.transform.position = transform.position;

            Rigidbody2D rigid = bullet.GetComponent<Rigidbody2D>();
            Vector3 dirVec = player.transform.position - transform.position;
            rigid.AddForce(dirVec.normalized * 5, ForceMode2D.Impulse);
        }
        else if (enemyName == "EnemyL")
        {
            GameObject bulletR = objectManager.MakeObj("BulletEnemyB");
            bulletR.transform.position = transform.position + Vector3.right * 0.3f;
            GameObject bulletL = objectManager.MakeObj("BulletEnemyB");
            bulletL.transform.position = transform.position + Vector3.left * 0.3f;

            Rigidbody2D rigidR = bulletR.GetComponent<Rigidbody2D>();
            Rigidbody2D rigidL = bulletL.GetComponent<Rigidbody2D>();

            Vector3 dirVecR = player.transform.position - (transform.position + Vector3.right * 0.3f);
            Vector3 dirVecL = player.transform.position - (transform.position + Vector3.right * 0.3f);

            rigidR.AddForce(dirVecR.normalized * 10, ForceMode2D.Impulse);
            rigidL.AddForce(dirVecL.normalized * 10, ForceMode2D.Impulse);
        }

        curShotDelay = 0;
    }

    void OnHit(int dmg)
    {
        health -= dmg;
        spriteRenderer.sprite = sprites[1];
        Invoke("ReturnSprite", 0.1f);
        ChangeHealthText();
        
        
        if (health <= 0)
        {

           
            
            gameObject.SetActive(false);
            return;
        }

    }

    //GameObject playerObject = GameObject.FindGameObjectWithTag("Player");

    //    OnPickedUp(playerObject);

    public void ChangeHealthText()
    {
        CurrentHpTxt.text = health.ToString();
    }
    void ReturnSprite()
    {
        spriteRenderer.sprite = sprites[0];
    }

    void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.tag == "BorderBullet")
        {
            gameObject.SetActive(false);
        }
        else if (collision.gameObject.tag == "PlayerBullet")
        {
            Bullet bullet = collision.gameObject.GetComponent<Bullet>();
            OnHit(bullet.dmg);

            collision.gameObject.SetActive(false);
        }
    }


    //void OnPickedUp(GameObject receiver)
    //{
    //    CharacterStatsHandler statsHandler = receiver.GetComponent<CharacterStatsHandler>();
    //    foreach (CharacterStats stat in statsModifier)
    //    {
    //        statsHandler.AddStatModifier(stat);
    //    }
    //}
}

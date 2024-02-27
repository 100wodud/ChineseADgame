using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class GameManager : MonoBehaviour
{
    public static GameManager I;

    public string Bullet;
    public string[] colliderObjs;
    public Transform[] spawnPoints;

    public float maxSpawnDelay;
    public float curSpawnDelay;
    public float itemSpawnDelay;
    public float spawnDelay;

    int level = 0;

    public float Score;

    public ObjectManager objectManager;

    public TextMeshProUGUI scoreText;

    public GameObject[] enemyObjs;

    public GameObject[] itemObjs;


    public GameObject player;



    void Awake()
    {
        colliderObjs = new string[] { "WallT", "WallB" };
        Bullet = "Bullet";
        if (I != null) //이미 존재하면
        {
            Destroy(gameObject); //두개 이상이니 삭제
            return;
        }
        I = this;

    }
    void Update()
    {
        curSpawnDelay += Time.deltaTime;
        itemSpawnDelay += Time.deltaTime;
        Score += Time.deltaTime * 10;
        scoreText.text = Score.ToString("N1");

        if (curSpawnDelay > maxSpawnDelay)
        {
            //SpawnCollider();
            SpawnEnemy();

            maxSpawnDelay = Random.Range(0.5f, 3f);
            curSpawnDelay = 0f;
        }

        if (itemSpawnDelay > maxSpawnDelay + 5)
        {
            SpawnItem();
            itemSpawnDelay = 0f;
        }

        if ((int)Score / 100 > level)
        {
            level = (int)Score / 100;
            InvokeRepeating("SpawnBullet", 5f, level);
            spawnDelay -= 0.5f;

        }

        void SpawnCollider()
        {
            int ranCollider = Random.Range(0, 2);
            int ranPoint = Random.Range(0, 5);

            GameObject wall = objectManager.MakeObj(colliderObjs[ranCollider]);
            wall.transform.position = spawnPoints[ranPoint].position;
        }

        void SpawnBullet()
        {
            float randX = 20f;
            float randY = Random.Range(-4, 4);
            transform.position = new Vector3(randX, randY, 0);
            GameObject wall = objectManager.MakeObj(Bullet);
            wall.transform.position = transform.position;
        }

        void SpawnEnemy()
        {
            int ranEnemy = Random.Range(0, 3);
            int ranPoint = Random.Range(0, 5);
            GameObject enemy = Instantiate(enemyObjs[ranEnemy], spawnPoints[ranPoint].position, spawnPoints[ranPoint].rotation);

            Rigidbody2D rigid = enemy.GetComponent<Rigidbody2D>();
            Enemy enemyLogic = enemy.GetComponent<Enemy>();
            enemyLogic.player = player;
        }

        void SpawnItem()
        {
            int ranItem = Random.Range(0, 3);
            int ranItem2 = Random.Range(0, 3);
            int ranItem3 = Random.Range(0, 3);


            Vector3 secondItemPosition = spawnPoints[1].position + new Vector3(2f, 0f, 0f);
            Instantiate(itemObjs[ranItem2], secondItemPosition, spawnPoints[3].rotation);
            Vector3 thirdItemPosition = spawnPoints[1].position + new Vector3(-2f, 0f, 0f);
            Instantiate(itemObjs[ranItem3], thirdItemPosition, spawnPoints[3].rotation);
        }

    }
}
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
using UnityEngine.UI;
using UnityEngine.SceneManagement;
using System.IO;

public class GameManager : MonoBehaviour
{
    public static GameManager I;

    public string Bullet;
    public string[] colliderObjs;
    public Transform[] spawnPoints;

    public float nextSpawnDelay;
    public float curSpawnDelay;
    public float itemSpawnDelay;
    public float spawnDelay;

    int level = 0;

    public float Score;

    public ObjectManager objectManager;

    public TextMeshProUGUI scoreText;

    public string[] enemyObjs;

    public GameObject[] itemObjs;

    public GameObject player;
    public List<Spawn> spawnList;
    public int spawnIndex;
    public bool spawnEnd;


    void Awake()
    {
        spawnList = new List<Spawn>();
        enemyObjs = new string[] { "EnemyS", "EnemyM", "EnemyL" };
        ReadSpawnFile();
        if (I != null) //이미 존재하면
        {
            Destroy(gameObject); //두개 이상이니 삭제
            return;
        }
        I = this;

    }

    void ReadSpawnFile()
    {
        // 변수 초기화
        spawnList.Clear();
        spawnIndex = 0;
        spawnEnd = false;

        // 리스폰 파일 읽기
        TextAsset textFile = Resources.Load("Stage 0") as TextAsset;
        StringReader stringReader = new StringReader(textFile.text); //파일 내의 문자열 데이터 읽기 클래스

        while(stringReader != null)
        {
            string line = stringReader.ReadLine();
            Debug.Log(line);

            if(line == null)
                break;

            // 리스폰 데이터 생성
            Spawn spawnData = new Spawn();
            spawnData.delay = float.Parse(line.Split(',')[0]);
            spawnData.type = line.Split(',')[1];
            spawnData.point = int.Parse(line.Split(',')[2]);
            spawnList.Add(spawnData);
        }
        // 텍스트 파일 닫기
        stringReader.Close();

        // 첫번째 스폰 딜레이 적용
        nextSpawnDelay = spawnList[0].delay;
    }
    void Update()
    {
        curSpawnDelay += Time.deltaTime;
        itemSpawnDelay += Time.deltaTime;
        Score += Time.deltaTime * 10;
        scoreText.text = Score.ToString("N1");

        if (curSpawnDelay > nextSpawnDelay && !spawnEnd)
        {
            //SpawnCollider();
            SpawnEnemy();
            curSpawnDelay = 0f;
        }

        if (itemSpawnDelay > nextSpawnDelay + 5)
        {
            //SpawnItem();
            itemSpawnDelay = 0f;
        }

        if ((int)Score / 100 > level)
        {
            level = (int)Score / 100;
            InvokeRepeating("SpawnBullet", 5f, level);
            spawnDelay -= 0.5f;

        }
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
            int enemyIndex = 0;
            switch (spawnList[spawnIndex].type)
            {
                case "S":
                    enemyIndex = 0;
                    break;
                case "M":
                    enemyIndex = 1;
                    break;
                case "L":
                    enemyIndex = 2;
                    break;
            }
            int enemyPoint = spawnList[spawnIndex].point;
            GameObject enemy = objectManager.MakeObj(enemyObjs[enemyIndex]);
            enemy.transform.position = spawnPoints[enemyPoint].position;

            Rigidbody2D rigid = enemy.GetComponent<Rigidbody2D>();
            Enemy enemyLogic = enemy.GetComponent<Enemy>();
            enemyLogic.player = player;
            enemyLogic.objectManager = objectManager;

            rigid.velocity = new Vector2(0, enemyLogic.speed * (-1));

            // 리스폰 인덱스 증가
            spawnIndex++;
            if(spawnIndex == spawnList.Count)
            {
                spawnEnd = true;
                return;
            }

            // 다음 리스폰 딜레이 갱신
            nextSpawnDelay = spawnList[spawnIndex].delay;

        }

        //void SpawnItem()
        //{
        //    int ranItem = Random.Range(0, 3);
        //    int ranItem2 = Random.Range(0, 3);
        //    int ranItem3 = Random.Range(0, 3);


        //    Vector3 secondItemPosition = spawnPoints[0].position + new Vector3(2f, 0f, 0f);
        //    Instantiate(itemObjs[ranItem2], secondItemPosition, spawnPoints[3].rotation);
        //    Vector3 thirdItemPosition = spawnPoints[0].position + new Vector3(-2f, 0f, 0f);
        //    Instantiate(itemObjs[ranItem3], thirdItemPosition, spawnPoints[3].rotation);
        //}

}
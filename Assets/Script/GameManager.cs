using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.UIElements;

public class GameManager : MonoBehaviour
{
    public GameObject[] Item;
    public GameObject[] enemyObs;
    public Transform[] spawnPoints;
    public GameObject BossEnem;
    public bool isPaused;
    public float maxEnemySpawnDelay;
    private float curEnemySpawnDelay;

    public GameObject UIManager;
    private UI ui;

    public int bossCount;

    public GameObject pauseMenu;
    public GameObject GameOverMenu;
    public UnityEngine.UI.Button resumeButton;

    public bool isBoss;

    public float maxItemSpawnDelay = 20f;
    private float curItemSpawnDelay;

    public int enemyNum;

    void Start()
    {
        ui = UIManager.GetComponent<UI>();
        Time.timeScale = 1.0f;
        isPaused = false;
        resumeButton.onClick.AddListener(Pause);
    }
    void Update()
    {
        if (Input.GetButtonDown("Cancel"))
        {
            Pause();
        }
        if (isBoss == false) {
            if (bossCount == 40)
            {
                Vector3 trans = new Vector3(0f, 8f, 0f);
                Instantiate(BossEnem, trans, transform.rotation);
                bossCount = 0;
                isBoss = true;
            }
            SpawnEnem();
        }
        GameOverCheck();
        SpawnIte();
    }
    void SpawnIte()
    {
        curItemSpawnDelay += Time.deltaTime;

        if (curItemSpawnDelay >= maxItemSpawnDelay)
        {
            SpawnItem();
            maxItemSpawnDelay = Random.Range(7f, 30f);
            curItemSpawnDelay = 0;
        }
    }
    void SpawnItem()
    {
        int ItemNum = Random.Range(0, 2);

        int ranPoint = Random.Range(1, 5);
        GameObject item = Instantiate(Item[ItemNum], spawnPoints[ranPoint].position, spawnPoints[ranPoint].rotation);
        Rigidbody2D rigid = item.GetComponent<Rigidbody2D>();
        Item itemLogic = item.GetComponent<Item>();
        if (ranPoint <= 3 && ranPoint > 0)
        {//front
            rigid.velocity = new Vector2(0, 3 * (-1));
            itemLogic.Direction = "Front";
        }
        else if (ranPoint == 0 || ranPoint == 6)//left
        {
            rigid.velocity = new Vector2(3, -1);
            itemLogic.Direction = "Left";
        }
        else if (ranPoint == 4 || ranPoint == 5)//right
        {
            rigid.velocity = new Vector2(3 * (-1), -1);
            itemLogic.Direction = "Right";
        }
    }
    void SpawnEnem()
    {
        curEnemySpawnDelay += Time.deltaTime;

        if (curEnemySpawnDelay >= maxEnemySpawnDelay)
        {
            SpawnEnemy();
            maxEnemySpawnDelay = Random.Range(0.7f, 2f);
            curEnemySpawnDelay = 0;
        }
    }
    void SpawnEnemy()
    {
        int ranEnemy = Random.Range(1, 100);
        Debug.Log(ranEnemy);
        if (ranEnemy < 60)
        {
            enemyNum = 0;
        }
        else if (ranEnemy < 85)
        {
            enemyNum = 1;
        }
        else if (ranEnemy <= 100)
        {
            enemyNum = 2;
        }

        int ranPoint = Random.Range(0, 7);
        bossCount++;
        GameObject enemy = Instantiate(enemyObs[enemyNum], spawnPoints[ranPoint].position, spawnPoints[ranPoint].rotation);
        Rigidbody2D rigid = enemy.GetComponent<Rigidbody2D>();
        Enemy enemyLogic = enemy.GetComponent<Enemy>();
        if (ranPoint <= 3 && ranPoint > 0) {//front
            rigid.velocity = new Vector2(0, enemyLogic.speed * (-1));
            enemyLogic.Direction = "Front";
        }
        else if (ranPoint == 0 || ranPoint == 6)//left
        {
            rigid.velocity = new Vector2(enemyLogic.speed, -1);
            enemyLogic.Direction = "Left";
        }
        else if (ranPoint == 4 || ranPoint == 5)//right
        {
            rigid.velocity = new Vector2(enemyLogic.speed * (-1), -1);
            enemyLogic.Direction = "Right";
        }
    }
    void GameOverCheck()
    {
        Debug.Log("메서드 밖");
        if (ui.CurHp <= 0 || ui.CurPain >= 300)
        {
            isPaused= true;
            GameOver();
            Debug.Log("메서드 속");
        }
    }
    void GameOver()
    {
        GameOverMenu.SetActive(true);
        Time.timeScale = isPaused ? 0.0f : 1.0f;

        GameObject playerObj = GameObject.FindGameObjectWithTag("Player");
        if (playerObj != null)
        {
            MonoBehaviour[] scripts = playerObj.GetComponents<MonoBehaviour>();
            foreach (MonoBehaviour script in scripts)
            {
                script.enabled = !isPaused;
            }
        }
}
    void Pause()
    {
        isPaused = !isPaused;

        if (pauseMenu.activeSelf)
        {
            isPaused = false;
            pauseMenu.SetActive(false);
        }
        else
        {
            isPaused = true;
            pauseMenu.SetActive(true);
        }

        Time.timeScale = isPaused ? 0.0f : 1.0f;

        GameObject playerObj = GameObject.FindGameObjectWithTag("Player");
        if (playerObj != null)
        {
            MonoBehaviour[] scripts = playerObj.GetComponents<MonoBehaviour>();
            foreach (MonoBehaviour script in scripts)
            {
                script.enabled = !isPaused;
            }
        }
    }
}

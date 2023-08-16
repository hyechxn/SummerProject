using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameManager : MonoBehaviour
{
    public GameObject[] Item;
    public GameObject[] enemyObs;
    public Transform[] spawnPoints;

    public float maxEnemySpawnDelay;
    private float curEnemySpawnDelay;

    public float maxItemSpawnDelay= 30f;
    private float curItemSpawnDelay;

    private int enemyNum;
    void Update()
    {
        SpawnEnem();
        SpawnIte();
    }
    void SpawnIte()
    {
        curItemSpawnDelay += Time.deltaTime;

        if (curItemSpawnDelay >= maxItemSpawnDelay)
        {
            SpawnItem();
            maxItemSpawnDelay = Random.Range(7f, 20f);
            curItemSpawnDelay = 0;
        }
    }
    void SpawnItem()
    {
        int ItemNum = Random.Range(0, 1);

        int ranPoint = Random.Range(1, 5);
        Instantiate(Item[ItemNum], spawnPoints[ranPoint].position, spawnPoints[ranPoint].rotation);
    }
    void SpawnEnem()
    {
        curEnemySpawnDelay += Time.deltaTime;

        if (curEnemySpawnDelay >= maxEnemySpawnDelay)
        {
            SpawnEnemy();
            maxEnemySpawnDelay = Random.Range(0.7f, 3f);
            curEnemySpawnDelay = 0;
        }
    }
    void SpawnEnemy()
    {
        int ranEnemy = Random.Range(1,100);
        Debug.Log(ranEnemy);
        if (ranEnemy < 60)
        {
            enemyNum = 0;
        }
        else if (ranEnemy < 85 )
        {
            enemyNum = 1;
        }
        else if (ranEnemy <= 100)
        {
            enemyNum= 2;
        }

        int ranPoint = Random.Range(1, 5);
        Instantiate(enemyObs[enemyNum], spawnPoints[ranPoint].position, spawnPoints[ranPoint].rotation);
    }
}

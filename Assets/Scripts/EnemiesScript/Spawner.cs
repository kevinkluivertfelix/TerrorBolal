using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Spawner : MonoBehaviour
{
    [SerializeField] private GameObject enemyPrefab;
    [SerializeField] private int sizeOfPool;
    [SerializeField] private List<GameObject> enemiesPoolList = new List<GameObject>();
    [SerializeField] private float timeToSpawn;
    private float time;
    private PoolingManager pooling;
    GameObject enemyPool;

    private void Awake()
    {
        enemyPool = new GameObject("EnemyPool");
    }

    private void Start()
    {
        pooling = PoolingManager.instance;
        pooling.ObjectPooling(enemiesPoolList, enemyPrefab, enemyPool, sizeOfPool);
    }

    private void Update()
    {
        time += Time.deltaTime;
        SpawnTimer();
    }


    void SpawnTimer()
    {
        if (time >= timeToSpawn)
        {
            SpawnEnemy();
            time = 0f;
        }
    }

    private void SpawnEnemy()
    {
        GameObject enemyPrefab = pooling.GetPooledObjects(enemiesPoolList);

        if (enemyPrefab == null)
            return;

        enemyPrefab.transform.position = new Vector2(gameObject.transform.position.x, Random.Range(-3.5f, 3.5f));
        enemyPrefab.transform.rotation = gameObject.transform.rotation;
        enemyPrefab.SetActive(true);
    }
}

using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Spawner : MonoBehaviour
{
    [SerializeField] private int totalEnemiesToSpawn;
    public List<GameObject> enemiesList = new List<GameObject>();
    public bool canSpawn;

    public float timerBetweenSpawn;
    private float timeCount;

    

    private void Start()
    {
        canSpawn = true;
    }

    private void Update()
    {
        timeCount += Time.deltaTime;

        if(timeCount >= timerBetweenSpawn && canSpawn)
        {
            SpawnEnemy();
            timeCount = 0f;
        }
    }

    void SpawnEnemy()
    {
        Instantiate(enemiesList[Random.Range(0, enemiesList.Count)], transform.position + new Vector3(0,Random.Range(-4f,3f), 0), transform.rotation);
    }
}

using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyInstantiation : MonoBehaviour
{
    public GameObject EnemyToSpawn;
    //public int enemyKillCap;
    //public int enemyKillCount;
    public int CurrentEnemyCount = 0;
    public int TotalenemyCount = 7;
    public List<Transform> spawns;
    public float spawnTime = 0.5f;
    public static EnemyInstantiation instance;

    private void Awake()
    {
        instance = this;
    }

    // Start is called before the first frame update
    void Start()
    {
        InvokeRepeating("SpawnEnemy", spawnTime, spawnTime);
    }

    void SpawnEnemy()
    {
        
        if (CurrentEnemyCount < TotalenemyCount)
        {
            Debug.Log("I spawn shtuff");
            int spawnToSpawnAt = Random.Range(0, spawns.Count);

            GameObject enemy = Instantiate(EnemyToSpawn, spawns[spawnToSpawnAt].position, spawns[spawnToSpawnAt].rotation);

            CurrentEnemyCount++;
        }
    }
}

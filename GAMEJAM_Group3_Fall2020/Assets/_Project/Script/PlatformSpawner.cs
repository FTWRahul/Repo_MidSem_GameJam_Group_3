using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlatformSpawner : MonoBehaviour
{
    public float SpawnRate;
    public int spawnChance;
    float NextSpawnTime;
    public GameObject[] Prefab;
    ObjectPooler objectPooler;

    // Start is called before the first frame update
    void Start()
    {
        NextSpawnTime = Time.time;
        objectPooler = ObjectPooler.Instance;
    }
    
    // Update is called once per frame
    void Update()
    {
        float Rate = SpawnRate * GameManager.WorldSimulationSpeed;

        if (NextSpawnTime < Time.time)
        {
            objectPooler.SpawnFromPool(Prefab[Random.Range(0, Prefab.Length)], transform.position, Quaternion.identity);
            NextSpawnTime += Rate;
        }
    }
}

using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlatformSpawner : MonoBehaviour
{
    public float SpawnRate;
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
        if (NextSpawnTime < Time.time)
        {
            objectPooler.SpawnFromPool(Prefab[Random.Range(0, Prefab.Length)], transform.position, Quaternion.identity);
            NextSpawnTime += SpawnRate;
        }
    }
}

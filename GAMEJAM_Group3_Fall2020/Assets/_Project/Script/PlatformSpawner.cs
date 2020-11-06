using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlatformSpawner : MonoBehaviour
{

    float _timeSinceLastSpawn = 0;
    float _nextSpawnTime = 0;
    public float minRate;
    public float maxRate;
    public GameObject[] Prefab;
    ObjectPooler objectPooler;

    // Start is called before the first frame update
    void Start()
    {
        objectPooler = ObjectPooler.Instance;
        _nextSpawnTime = Random.Range(minRate, maxRate);
    }
    
    // Update is called once per frame
    void Update()
    {
        if (_timeSinceLastSpawn >= _nextSpawnTime)
        {
            SpawnObject();
        }
        else
        {
            _timeSinceLastSpawn += Time.deltaTime * GameManager.WorldSimulationSpeed;
        }
    }

    private void SpawnObject()
    {
        int randIndex = Random.Range(0, Prefab.Length);
        float randTime = Random.Range(minRate, maxRate);
        objectPooler.SpawnFromPool(Prefab[randIndex], transform.position, Quaternion.identity);
        _timeSinceLastSpawn = 0;
        _nextSpawnTime = randTime;
    }
}


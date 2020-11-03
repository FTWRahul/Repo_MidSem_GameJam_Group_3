using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlatformSpawner : MonoBehaviour
{
    public float SpawnRate;
    float NextSpawnTime;

    public GameObject[] Platforms;

    // Start is called before the first frame update
    void Start()
    {
        NextSpawnTime = Time.time;
    }

    // Update is called once per frame
    void Update()
    {
        if (NextSpawnTime < Time.time)
        {
            Instantiate(Platforms[Random.Range(0, Platforms.Length)], 
                new Vector3(transform.position.x, transform.position.y, transform.position.z), 
                Quaternion.identity);
            NextSpawnTime += SpawnRate;
        }
    }
}

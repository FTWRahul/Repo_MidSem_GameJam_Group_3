using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ObjectPooler : MonoBehaviour
{
    public GameObject TestPreFab;

    [System.Serializable]
    public class Pool
    {
        public GameObject Prefab;
        public int Size;
    }

    public static ObjectPooler Instance;

    private void Awake()
    {
        Instance = this;
    }

    public List<Pool> Pools;
    public Dictionary<GameObject, Queue<GameObject>> poolDictionary;

    // Start is called before the first frame update
    void Start()
    {
        poolDictionary = new Dictionary<GameObject, Queue<GameObject>>();
        
        foreach (Pool pool in Pools)
        {
            Queue<GameObject> ObjectPool = new Queue<GameObject>();

            for (int i = 0; i < pool.Size; i++)
            {
                GameObject obj = Instantiate(pool.Prefab);
                obj.SetActive(false);
                ObjectPool.Enqueue(obj);
            }

            poolDictionary.Add(pool.Prefab, ObjectPool);
        }
    }

    public GameObject SpawnFromPool(GameObject Prefab, Vector2 Position, Quaternion Rotation)
    {
        if (!poolDictionary.ContainsKey(Prefab))
        {
            Debug.LogWarning("Pool with tag " + Prefab + "doesn't exist.");
            return null;
        }

        GameObject objectToSpawn = poolDictionary[Prefab].Dequeue();

        objectToSpawn.SetActive(true);
        objectToSpawn.transform.position = Position;
        objectToSpawn.transform.rotation = Rotation;

        poolDictionary[Prefab].Enqueue(objectToSpawn);

        return objectToSpawn;
    }

    
    public void ReturnToPool (GameObject Prefab)
    {
        if (!poolDictionary.ContainsKey(Prefab))
        {
            Debug.LogWarning("Pool with tag " + Prefab + "doesn't exist.");
            return;
        }

        foreach (var currentPrefab in poolDictionary[Prefab])
        {
            currentPrefab.SetActive(false);
        }

    }
}

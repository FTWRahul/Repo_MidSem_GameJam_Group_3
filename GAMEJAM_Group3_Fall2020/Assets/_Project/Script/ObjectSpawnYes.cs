using UnityEngine;

public class ObjectSpawnYes : MonoBehaviour
{
    public GameObject objectToSpawn;

    public void SpawnThing()
    {
        Instantiate(objectToSpawn, transform.position, Quaternion.identity);
    }
}
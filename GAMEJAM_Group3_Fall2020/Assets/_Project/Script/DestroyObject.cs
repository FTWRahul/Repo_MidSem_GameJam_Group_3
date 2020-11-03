using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DestroyObject : MonoBehaviour
{
    public float Duration;

    private void Awake()
    {
        Destroy(gameObject, Duration); // Destroys game object after a given duration.
    }
}

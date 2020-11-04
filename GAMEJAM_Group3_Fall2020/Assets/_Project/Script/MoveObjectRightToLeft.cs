using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MoveObjectRightToLeft : MonoBehaviour
{
    public float Speed;
    Rigidbody2D MovingObject;

    private void Awake()
    {
        MovingObject = GetComponent<Rigidbody2D>();
    }

    // Start is called before the first frame update
    void Start()
    {
        MovingObject.velocity = new Vector2(-Speed * GameManager.WorldSimulationSpeed, 0);
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}

using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MoveObjectRightToLeft : MonoBehaviour
{
    public float _speed;
    Rigidbody2D MovingObject;

    public float Speed
    {
        get => _speed;
        set => _speed = value;
    }

    private void Awake()
    {
        MovingObject = GetComponent<Rigidbody2D>();
    }

    // Start is called before the first frame update
    void Start()
    {
    }

    // Update is called once per frame
    void Update()
    {
        MovingObject.velocity = new Vector2(-Speed * GameManager.WorldSimulationSpeed, 0);
    }
}

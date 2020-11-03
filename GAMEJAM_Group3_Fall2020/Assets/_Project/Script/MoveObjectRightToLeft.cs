using Player;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MoveObjectRightToLeft : BasePlayerController
{
    public float Speed;
    Rigidbody2D _rigidbody2D;

    private void Awake()
    {
        _rigidbody2D = GetComponent<Rigidbody2D>();
    }

    // Start is called before the first frame update
    void Start()
    {
        _rigidbody2D.velocity = new Vector2(-Speed, 0);
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}

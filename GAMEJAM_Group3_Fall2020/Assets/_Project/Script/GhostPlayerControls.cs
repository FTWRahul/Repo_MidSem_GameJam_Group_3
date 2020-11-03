using System.Collections;
using System.Collections.Generic;
using System.Linq.Expressions;
using UnityEngine;

public class GhostPlayerControls : MonoBehaviour
{
    public float GhostMoveDistance = 350;
    Rigidbody2D Ghost;
    float Move;

    // Start is called before the first frame update
    void Start()
    {
        Ghost = GetComponent<Rigidbody2D>();
    }

    // Update is called once per frame
    void Update()
    {
        Move = Input.GetAxis("Vertical");
        GhostMovement();
    }

    void GhostMovement()
    {
        Ghost.velocity = new Vector3(0, Move * GhostMoveDistance * Time.deltaTime, 0);
    }
}

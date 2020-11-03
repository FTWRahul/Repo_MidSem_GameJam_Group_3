using System.Collections;
using System.Collections.Generic;
using System.Linq.Expressions;
using UnityEngine;

public class GhostPlayerControls : MonoBehaviour
{
    public float GhostMoveDistance = 1;
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
        moveTranslation();
    }

    void moveTranslation()
    {
        transform.position = new Vector3(transform.position.x, transform.position.y + (Move * GhostMoveDistance * Time.deltaTime), transform.position.z);
    }
}

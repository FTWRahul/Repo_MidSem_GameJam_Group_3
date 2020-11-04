using System.Collections;
using System.Collections.Generic;
using System.Linq.Expressions;
using UnityEngine;

namespace Player 
{
    public class GhostPlayerControls : BasePlayerControls
    {
        public float GhostMoveDistance = 350;
        float Move;

        // Start is called before the first frame update
        void Start()
        {
            _rigidbody2D = GetComponent<Rigidbody2D>();
        }

        // Update is called once per frame
        void Update()
        {
            Move = Input.GetAxis("Vertical");
            GhostMovement();
        }

        void GhostMovement()
        {
            _rigidbody2D.velocity = new Vector3(0, Move * GhostMoveDistance * Time.deltaTime, 0);
        }

    }
}

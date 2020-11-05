using UnityEngine;

namespace Player.Movement 
{
    public class GhostPlayerControls : BasePlayerControls
    {
        public float GhostMoveDistance = 350;
        float Move;
        
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

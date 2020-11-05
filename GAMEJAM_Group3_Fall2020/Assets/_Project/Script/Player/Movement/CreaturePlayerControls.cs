using System;
using UnityEngine;

namespace Player.Movement
{
    /// <summary>
    /// The controls when the player is in his creature mode.
    /// </summary>
    public class CreaturePlayerControls : BasePlayerControls
    {
        [Header("Parameters")]
        //Exposed fields
        [Tooltip("How high the player jumps")]
        [SerializeField] private float jumpForce;
        [Tooltip("How far away can the ground be detected from")]
        [SerializeField] private float groundedDistance;
        [Tooltip("How long before player can jump again? Note: Treat this as margin of error, should be a very small value")]
        [SerializeField] private float jumpTimeThreshold;
        [Tooltip("How long is the player's input stored?")]
        [SerializeField] private float jumpCacheDuration;
        [Tooltip("What layers can the player jump off of.")]
        [SerializeField] private LayerMask groundLayerMask;
        
        //Private members
        private float _timeBetweenLastJump;
        private float _timeSinceJumpCached;
        private bool _isGrounded;
        
        //Private Properties
        private bool hasJumpAvaliable => _timeBetweenLastJump >= jumpTimeThreshold;
        private bool JumpCached => _timeSinceJumpCached < jumpCacheDuration;
        private bool CanJump =>  hasJumpAvaliable && IsGrounded && JumpCached;

        public bool IsGrounded => _isGrounded;
        public event Action playerJumped;

        private void FixedUpdate()
        {
            _isGrounded = GroundCheck();
            
            CacheJumpInput();
            
            if (CanJump) 
            {
                Jump();
                _timeBetweenLastJump = 0;
            }

            UpdateJumpCache();
            
            UpdateJumpThreshold();
        }

        private void UpdateJumpThreshold()
        {
            if (!hasJumpAvaliable)
            {
                _timeBetweenLastJump += Time.fixedDeltaTime;
            }
        }

        private void UpdateJumpCache()
        {
            if (JumpCached)
            {
                _timeSinceJumpCached += Time.fixedDeltaTime;
            }
            else
            {
                _timeSinceJumpCached = jumpCacheDuration;
            }
        }

        private void CacheJumpInput()
        {
            if (Input.GetButtonDown("Jump"))
            {
                _timeSinceJumpCached = 0;
            }
        }

        private bool GroundCheck()
        {
            return Physics2D.Raycast(transform.position, transform.up * -1, groundedDistance, groundLayerMask);
        }

        private void Jump()
        {
            _rigidbody2D.AddForce(Vector2.up * (jumpForce * Time.fixedDeltaTime), ForceMode2D.Impulse);
            playerJumped?.Invoke();
        }

        //Visualization for the grounded raycast check
        private void OnDrawGizmos()
        {
            Gizmos.color = Color.red;
            Gizmos.DrawRay(transform.position, transform.up * -1f * groundedDistance );
        }
    }
}
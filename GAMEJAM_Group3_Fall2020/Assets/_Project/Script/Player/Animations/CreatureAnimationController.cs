using Player.Movement;
using UnityEngine;

namespace Player.Animations
{
    public class CreatureAnimationController : BaseAnimationController
    {
        private CreaturePlayerControls _creaturePlayer;
        private static readonly int IsGroundedHash = Animator.StringToHash("isGrounded");
        private static readonly int JumpHash = Animator.StringToHash("Jump");

        protected override void Awake()
        {
            base.Awake();
            _creaturePlayer = GetComponent<CreaturePlayerControls>();
            _creaturePlayer.playerJumped += () => _animator.SetTrigger(JumpHash);
        }

        private void Update()
        {
            _animator.SetBool(IsGroundedHash, _creaturePlayer.IsGrounded);
        }

        private void OnDestroy()
        {
            _creaturePlayer.playerJumped -= () => _animator.SetTrigger("Jump");
        }
    }
}

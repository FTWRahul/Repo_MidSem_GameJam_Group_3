using UnityEngine;

namespace Player.Animations
{
    public class GhostAnimationController : BaseAnimationController
    {
        private static readonly int MovementAxis = Animator.StringToHash("MovementAxis");

        public void TurnOnRootMotion()
        {
            _animator.applyRootMotion = true;
        }
        public void TurnOffRootMotion()
        {
            _animator.applyRootMotion = false; //!_animator.hasRootMotion;
        }

        private void Update()
        {
            _animator.SetFloat(MovementAxis,Input.GetAxis("Vertical"));
        }
    }
}

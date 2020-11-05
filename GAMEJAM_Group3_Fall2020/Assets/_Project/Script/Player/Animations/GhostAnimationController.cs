using UnityEngine;

namespace Player.Animations
{
    public class GhostAnimationController : BaseAnimationController
    {
        private static readonly int MovementAxis = Animator.StringToHash("MovementAxis");

        public void ToggleRootMotion()
        {
            _animator.applyRootMotion = !_animator.hasRootMotion;
        }

        private void Update()
        {
            _animator.SetFloat(MovementAxis,Input.GetAxis("Vertical"));
        }
    }
}

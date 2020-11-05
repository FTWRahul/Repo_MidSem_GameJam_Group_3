using System;
using UnityEngine;

namespace Player.Animations
{
    public class BaseAnimationController : MonoBehaviour
    {
        protected Animator _animator;

        protected virtual void Awake()
        {
            _animator = GetComponent<Animator>();
        }


    }
}
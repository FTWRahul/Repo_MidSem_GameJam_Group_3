using System.Collections;
using Player.Movement;
using UnityEngine;

namespace Player
{
    public class LandingSound : MonoBehaviour
    {
        private CreaturePlayerControls _playerControls;
        private AudioSource _audioSource;
        private void Awake()
        {
            _playerControls = GetComponentInParent<CreaturePlayerControls>();
            _audioSource = GetComponent<AudioSource>();
            _playerControls.playerJumped += PlayLandingAudio;
        }

        public void PlayLandingAudio()
        {
            StartCoroutine(WaitForLanding());
        }

        private IEnumerator WaitForLanding()
        {
            while (!_playerControls.IsGrounded || !_playerControls.hasJumpAvaliable)
            {
                yield return new WaitForEndOfFrame();
            }
            _audioSource.Play();
        }

        private void OnDisable()
        {
            _playerControls.playerJumped -= PlayLandingAudio;
        }
    }
}
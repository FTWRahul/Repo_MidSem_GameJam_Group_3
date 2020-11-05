using Player.Movement;
using UnityEngine;

namespace Player
{
    public class FootstepsWhileGrounded : MonoBehaviour
    {
        private CreaturePlayerControls _creaturePlayer;
        private AudioSource _audioSource;
        private void Awake()
        {
            _creaturePlayer = GetComponentInParent<CreaturePlayerControls>();
            _audioSource = GetComponent<AudioSource>();
        }

        private void Update()
        {
            _audioSource.volume = _creaturePlayer.IsGrounded ? 1 : 0; 
        }
    }
}

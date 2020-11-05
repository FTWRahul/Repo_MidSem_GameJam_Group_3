using System;
using UnityEngine;

namespace Audio
{
    public class MusicManager : MonoBehaviour
    {
        public GameObject ghost;
        public GameObject creature;

        public AudioSource ghostMusic;
        public AudioSource creatureMusic;

        private void Update()
        {
            ghostMusic.volume = ghost.activeSelf ? 1 : 0;
            creatureMusic.volume = creature.activeSelf ? 1 : 0;
        }
    }
}

using UnityEngine;

namespace Player
{
    public class PlayerController : MonoBehaviour
    {
        private IPlayerControls _ghostPlayer;
        private IPlayerControls _creaturePlayer;

        private void Awake()
        {
            _ghostPlayer = GetComponentInChildren<GhostPlayerControls>().GetComponent<IPlayerControls>();
            _creaturePlayer = GetComponentInChildren<CreaturePlayerControls>().GetComponent<IPlayerControls>();
        }
    }
}

using UnityEngine;
using UnityEngine.Events;

namespace Player
{
    public class PlayerController : MonoBehaviour
    {
        private IPlayerControls _ghostPlayer;
        private IPlayerControls _creaturePlayer;

        public UnityEvent OnDeath;
        
        private void Start()
        {
            GameObject tempObject = GetComponentInChildren<GhostPlayerControls>().gameObject;
            _ghostPlayer = GetComponentInChildren<GhostPlayerControls>();
            _creaturePlayer = GetComponentInChildren<CreaturePlayerControls>();
            _creaturePlayer.playerDamageResponse.OnDamageTaken.AddListener(SwitchToGhost);
            tempObject.SetActive(false);
        }

        public void SwitchToGhost()
        {
            _creaturePlayer.playerDamageResponse.OnDamageTaken.RemoveListener(SwitchToGhost);
            _creaturePlayer.TurnOff();
            _ghostPlayer.TurnOn();
            _ghostPlayer.playerDamageResponse.OnDamageTaken.AddListener(Die);
        }

        private void Die()
        {
            _ghostPlayer.playerDamageResponse.OnDamageTaken.RemoveListener(Die);
            //Whatever happens on Death
            
            OnDeath?.Invoke();
        }

        [ContextMenu("Switch to player")]
        public void SwitchToCreature()
        {
            //Listen again for if player takes damage
            _creaturePlayer.TurnOn();
            _ghostPlayer.TurnOff();
            _creaturePlayer.playerDamageResponse.OnDamageTaken.AddListener(SwitchToGhost);
        }
    }
}

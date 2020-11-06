using Player.Movement;
using UnityEngine;
using UnityEngine.Events;

namespace Player
{
    public class PlayerController : MonoBehaviour
    {
        private IPlayerControls _ghostPlayer;
        private IPlayerControls _creaturePlayer;
        
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
            GameManager.InvokeCreatureDeath();
            _creaturePlayer.TurnOff();
            _ghostPlayer.TurnOn();
            _ghostPlayer.playerDamageResponse.OnDamageTaken.AddListener(Die);
        }

        private void Die()
        {
            _ghostPlayer.playerDamageResponse.OnDamageTaken.RemoveListener(Die);
            //Whatever happens on Death
            GameManager.InvokeGhostDeath();
        }

        [ContextMenu("Switch to player")]
        public void SwitchToCreature()
        {
            //Listen again for if player takes damage
            GameManager.InvokeLifeObtained();
            _creaturePlayer.TurnOn();
            _ghostPlayer.TurnOff();
            _creaturePlayer.playerDamageResponse.OnDamageTaken.AddListener(SwitchToGhost);
        }
    }
}

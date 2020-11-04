using System;
using Player;
using UnityEngine;
using UnityEngine.Events;

namespace Collectables
{
    public class LightCollectable : MonoBehaviour , ICollectable
    {
        [SerializeField] private UnityEvent onCollected = new UnityEvent();
        private PlayerController _playerController;
        
        public UnityEvent OnCollected
        {
            get => onCollected;
            set => onCollected = value;
        }

        private void OnEnable()
        {
            if (_playerController == null)
            {
                _playerController = FindObjectOfType<PlayerController>();
            }

            onCollected.AddListener(_playerController.SwitchToCreature);
        }

        public void Collect()
        {
            onCollected?.Invoke();
            onCollected.RemoveListener(_playerController.SwitchToCreature);
        }
    }
}

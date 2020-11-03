using UnityEngine;
using UnityEngine.Events;

namespace Player
{
    [RequireComponent(typeof(Rigidbody2D))][RequireComponent(typeof(DamageResponse))]
    public class BasePlayerController : MonoBehaviour , IPlayerControls
    {
    
        [Header("Events")]
        [SerializeField] protected UnityEvent onTurnOn = new UnityEvent();
        [SerializeField] protected UnityEvent onTurnOff = new UnityEvent();

        protected Rigidbody2D _rigidbody2D;

        public DamageResponse playerDamageResponse { get; private set; }
        public UnityEvent OnTurnOn => onTurnOn;
        public UnityEvent OnTurnOff => onTurnOff;

        protected virtual void Awake()
        {
            playerDamageResponse = GetComponent<DamageResponse>();
            _rigidbody2D = GetComponent<Rigidbody2D>();
        }

        public virtual void TurnOn()
        {
            onTurnOn?.Invoke();
        }

        public virtual void TurnOff()
        {
            onTurnOff?.Invoke();
        }
    }
}
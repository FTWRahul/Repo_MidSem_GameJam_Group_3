using UnityEngine;
using UnityEngine.Events;

/// <summary>
/// The base Damage response.
/// Exposes an event to the editor, either extend this class or make supplementing scripts to make desired behaviour  
/// </summary>
public class DamageResponse : MonoBehaviour , ICollidable
{
    [SerializeField] private UnityEvent onDamageTaken = new UnityEvent();
    
    public UnityEvent OnDamageTaken
    {
        get => onDamageTaken;
        set => onDamageTaken = value;
    }

    [ContextMenu("TestDamage")]
    public virtual void TakeDamage()
    {
        onDamageTaken?.Invoke();
    }
}
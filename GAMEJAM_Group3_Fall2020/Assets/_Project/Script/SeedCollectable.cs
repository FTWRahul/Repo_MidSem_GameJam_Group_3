using UnityEngine;
using UnityEngine.Events;

public class SeedCollectable : MonoBehaviour, ICollectable
{
    public UnityEvent onCollected;

    public UnityEvent OnCollected
    {
        get => onCollected;
        set => onCollected = value;
    }

    public void Collect()
    {
        OnCollected?.Invoke();
    }
}
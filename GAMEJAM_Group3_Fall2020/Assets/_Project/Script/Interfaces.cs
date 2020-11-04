using UnityEngine.Events;

/// <summary>
/// Implement this interface on anything that has a damage response
/// </summary>
public interface ICollidable
{
    UnityEvent OnDamageTaken { get; set; }
    void TakeDamage();
}

public interface ICollectable
{
    UnityEvent OnCollected { get; set; }
    void Collect();
}

public interface IPlayerControls
{
    ICollidable playerDamageResponse { get; }
    UnityEvent OnTurnOn { get; }
    UnityEvent OnTurnOff { get; }
    void TurnOn();
    void TurnOff();
}
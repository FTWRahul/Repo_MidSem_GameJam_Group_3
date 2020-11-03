using UnityEngine.Events;

/// <summary>
/// Implement this interface on anything that has a damage response
/// </summary>
public interface ITakeDamage
{
    UnityEvent OnDamageTaken { get; set; }
    void TakeDamage();
}

public interface IPlayerControls
{
    DamageResponse playerDamageResponse { get; }
    UnityEvent OnTurnOn { get; }
    UnityEvent OnTurnOff { get; }
    void TurnOn();
    void TurnOff();
}
using UnityEngine;
using UnityEngine.Events;

public class PlayerEventListener : MonoBehaviour
{
    public UnityEvent OnCreatureDeath;
    public UnityEvent OnGhostDeath;
    public UnityEvent OnLifeObtained;
    
    private void Awake()
    {
        GameManager.OnCreatureDeath += CreatureDied;
        GameManager.OnGhostDeath += GhostDied;
        GameManager.OnLifeObtained += LifeObtained;
    }

    private void CreatureDied()
    {
        OnCreatureDeath?.Invoke();
    }

    private void GhostDied()
    {
        OnGhostDeath?.Invoke();
    }

    private void LifeObtained()
    {
        OnLifeObtained?.Invoke();
    }

    private void OnDisable()
    {
        GameManager.OnCreatureDeath -= CreatureDied;
        GameManager.OnGhostDeath -= GhostDied;
        GameManager.OnLifeObtained -= LifeObtained;
    }
    public void SetSimSpeed(float val)
    {
        GameManager.WorldSimulationSpeed = val;
    }
}

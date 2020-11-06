using System.Collections;
using System.Collections.Generic;
using UberPlanetary.Core.ExtensionMethods;
using UnityEngine;
using UnityEngine.Events;

public class PlayerEventListener : MonoBehaviour
{
    public UnityEvent OnCreatureDeath;
    public UnityEvent OnGhostDeath;
    public UnityEvent OnLifeObtained;
    public UnityEvent onGameOver;

    public float timeToLerp;
    public AnimationCurve fadeInCurve;
    
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
        StartCoroutine(StopSimulationSpeed(val, GameManager.WorldSimulationSpeed));
    }
    private IEnumerator StopSimulationSpeed(float val, float oldVal)
    {
        float t = 0;
        while (t <= timeToLerp)
        {
            GameManager.WorldSimulationSpeed = Mathf.Lerp(oldVal, val, fadeInCurve.Evaluate(t.Remap(0, timeToLerp, 0, 1)));
            t += Time.deltaTime;
            yield return new WaitForEndOfFrame();
        }
        onGameOver?.Invoke();
    }
}

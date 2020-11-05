using System;
using UnityEngine;

public class GameManager : MonoBehaviour
{
    private static GameManager _instance;

    public static GameManager Instance => _instance;


    public static event Action OnCreatureDeath;
    public static event Action OnLifeObtained;
    public static event Action OnGhostDeath;
    
    private static float _worldSimulationSpeed = 2f;

    public static float WorldSimulationSpeed
    {
        get => _worldSimulationSpeed;
        set => _worldSimulationSpeed = value;
    }
    
    private void Awake()
    {
        if (_instance == null)
        {
            _instance = this;
        }
        else
        {
            Destroy(gameObject);
        }
        DontDestroyOnLoad(gameObject);
    }

    public static void InvokeGhostDeath()
    {
        OnGhostDeath?.Invoke();
    }

    public static void InvokeLifeObtained()
    {
        OnLifeObtained?.Invoke();
    }

    public static void InvokeCreatureDeath()
    {
        OnCreatureDeath?.Invoke();
    }
}

using UnityEngine;

public class GameManager : MonoBehaviour
{
    private static GameManager _instance;

    public static GameManager Instance => _instance;
    
    
    private static float _worldSimulationSpeed = 1f;

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
}

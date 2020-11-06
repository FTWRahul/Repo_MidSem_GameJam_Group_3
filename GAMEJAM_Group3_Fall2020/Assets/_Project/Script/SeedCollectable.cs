using UnityEngine;
using UnityEngine.Events;
using UnityEngine.UI;
using TMPro;

public class SeedCollectable : MonoBehaviour, ICollectable
{
    public SeedUI seedUI;
    public static int numOfSeeds;
    public TextMeshProUGUI Score;
    public UnityEvent onCollected;


    private void Awake()
    {
        seedUI = FindObjectOfType<SeedUI>();
    }
    public UnityEvent OnCollected
    {
        get => onCollected;
        set => onCollected = value;
    }

    public void Collect()
    {
        OnCollected?.Invoke();
        numOfSeeds += 1;
        seedUI.IncrementScore();
    }

    //private void OnTriggerEnter2D(Collider2D other)
    //{
    //    if (other.gameObject.CompareTag("Ghost") || other.gameObject.CompareTag("Creature"))
    //    {
    //        Collect();
    //    }
    //}

    private void OnCollisionEnter2D(Collision2D other)
    {
        if (other.gameObject.CompareTag("Ghost") || other.gameObject.CompareTag("Creature"))
        {
            Collect();
        }
    }

}
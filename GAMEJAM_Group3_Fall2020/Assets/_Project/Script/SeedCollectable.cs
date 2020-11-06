using UnityEngine;
using UnityEngine.Events;
using UnityEngine.UI;
using TMPro;

public class SeedCollectable : MonoBehaviour, ICollectable
{
    public int numOfSeeds;
    public TextMeshProUGUI Score;
    public UnityEvent onCollected;

    public UnityEvent OnCollected
    {
        get => onCollected;
        set => onCollected = value;
    }

    public void Collect()
    {
        OnCollected?.Invoke();
        numOfSeeds += 1;
        Score.text = numOfSeeds.ToString();
    }

    private void OnTriggerEnter2D(Collider2D other)
    {
        if (other.gameObject.CompareTag("Ghost") || other.gameObject.CompareTag("Creature"))
        {
            Collect();
        }
    }
}
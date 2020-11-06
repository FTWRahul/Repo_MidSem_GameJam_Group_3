using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

public class TriggerEvents : MonoBehaviour
{
    public UnityEvent triggerEntered;
    public string[] tags;
    
    private void OnTriggerEnter2D(Collider2D other)
    {
        for (int i = 0; i < tags.Length; i++)
        {
            if (other.CompareTag(tags[i]))
            {
                triggerEntered?.Invoke();
                break;
            }
            
        }
        
    }
}

﻿using UnityEngine;
using UnityEngine.Events;

/// <summary>
/// Deals damage to any tags defined in the editor for this object.
/// </summary>
public class OnCollisionDealDamage : MonoBehaviour
{
    [SerializeField] private string[] damageableTag;
    [SerializeField] private UnityEvent Damaged;
 
    //Checks if the collision occurred with an object that has a damageable Tag we defined, if so deal damage and break out 
    private void OnTriggerEnter2D(Collider2D other)
    {
        foreach (var damageTag in damageableTag)
        {
            if (other.gameObject.CompareTag(damageTag))
            {
                other.gameObject.GetComponent<DamageResponse>()?.TakeDamage();
                Damaged?.Invoke();
                break;
            }
        }
    }

    //private void OnCollisionEnter2D(Collision2D other)
    //{
    //    foreach (var damageTag in damageableTag)
    //    {
    //        if (other.gameObject.CompareTag(damageTag))
    //        {
    //            other.gameObject.GetComponent<DamageResponse>()?.TakeDamage();
    //            break;
    //        }
    //    }
    //}
}
using UnityEngine;

/// <summary>
/// Deals damage to any tags defined in the editor for this object.
/// </summary>
public class OnCollisionDealDamage : MonoBehaviour
{
    [SerializeField] private string[] damageableTag;
 
    //Checks if the collision occurred with an object that has a damageable Tag we defined, if so deal damage and break out 
    private void OnCollisionEnter2D(Collision2D other)
    {
        foreach (var damageTag in damageableTag)
        {
            if (other.gameObject.CompareTag(damageTag))
            {
                other.gameObject.GetComponent<DamageResponse>()?.TakeDamage();
                break;
            }
        }
    }
}
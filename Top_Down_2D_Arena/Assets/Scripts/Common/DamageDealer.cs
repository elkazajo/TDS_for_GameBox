using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DamageDealer : MonoBehaviour
{
    public float damageAmount = 10;

    [SerializeField] private string[] targetTag = new string[] {"Player", "Enemy"};

    private Health health;

    private void OnTriggerEnter2D(Collider2D other)
    {
        if(other.CompareTag(targetTag[0]))
        {
            health = other.GetComponent<Health>();

            if (health != null)
            {
                health.TakeDamage(damageAmount);
            }
        }        
    }
}

using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BulletBehaviour : MonoBehaviour
{
    [SerializeField] private GameObject bulletImpactPrefab;    

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if(collision.CompareTag("Wall") || collision.CompareTag("Enemy") || collision.CompareTag("Obstacle"))
        {
            GameObject bulletImpact = Instantiate(bulletImpactPrefab, transform.position, transform.rotation);
            Destroy(gameObject);
        }        
    }

    private void OnBecameInvisible()
    {
        Destroy(gameObject);
    }
}

using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BulletBehaviour : MonoBehaviour
{
    [SerializeField] private GameObject bulletImpactPrefab;
    [SerializeField] private AudioManager audioManager;

    private void Awake()
    {
        audioManager = FindObjectOfType<AudioManager>();
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if(!gameObject.CompareTag("EnemyBullet"))
        {
            if (collision.CompareTag("Wall") || collision.CompareTag("Enemy") || collision.CompareTag("Obstacle"))
            {
                audioManager.Play("enemyHit");
                GameObject bulletImpact = Instantiate(bulletImpactPrefab, transform.position, transform.rotation);
                Destroy(gameObject);
            }
        }
        else
        {
            if (collision.CompareTag("Wall") || collision.CompareTag("Player") || collision.CompareTag("Obstacle"))
            {
                audioManager.Play("enemyHit");
                GameObject bulletImpact = Instantiate(bulletImpactPrefab, transform.position, transform.rotation);
                Destroy(gameObject);
            }
        }           
    }

    private void OnBecameInvisible()
    {
        Destroy(gameObject);
    }
}

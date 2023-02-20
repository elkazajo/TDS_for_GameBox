using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RocketBehaviour : BasePowerUp
{
    [SerializeField] private GameObject explosionPrefab;

    private void Start()
    {
        PlaySfx("rocketLaunch");
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.CompareTag("Wall"))
        {
            ExplodeRocket();
            Destroy(gameObject);
        }

        if (collision.gameObject.CompareTag("Enemy"))
        {
            Health enemyHealth = collision.gameObject.GetComponent<Health>();
            if (enemyHealth != null)
            {
                enemyHealth.TakeDamage(10);
            }

            ExplodeRocket();
            Destroy(gameObject);
        }
    }

    private void ExplodeRocket()
    {
        PlaySfx("explosion");
        GameObject explsoion = Instantiate(explosionPrefab, transform.position, Quaternion.identity);
    }
}

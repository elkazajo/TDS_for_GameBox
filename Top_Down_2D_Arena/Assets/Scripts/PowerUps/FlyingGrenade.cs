using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FlyingGrenade : MonoBehaviour
{
    [SerializeField] private float speed = 5f;
    [SerializeField] private float knockbackForce = 1.5f;
    [SerializeField] private float damage = 10f;
    [SerializeField] private float respawnTime = 2f;
    [SerializeField] private float distanceFromPlayer = 5.0f;
    [SerializeField] private GameObject smallExplosion;

    private Transform playerTransform;
    private Health enemyHealth;
    private string enemyTag = "Enemy";
    private string playerTag = "Player";

    private void Start()
    {
        playerTransform = GameObject.FindGameObjectWithTag(playerTag).transform;
    }

    private void Update()
    {
        transform.position = playerTransform.position + (Quaternion.Euler(0, 0, Time.time * 360f) * Vector3.up * distanceFromPlayer);
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.CompareTag(enemyTag))
        {
            enemyHealth = collision.GetComponent<Health>();
            if (enemyHealth != null)
            {
                enemyHealth.TakeDamage(damage);
            }
            GameObject explosion = Instantiate(smallExplosion, transform.position, transform.rotation);
        }
    }
}

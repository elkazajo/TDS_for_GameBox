using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FlyingGrenadeBehaviour : BasePowerUp
{
    [SerializeField] private GameObject smallExplosion;
    [SerializeField] private float distanceFromPlayer = 3.0f;

    private Transform playerTransform;
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
            PlaySfx("explosion");
            GameObject explosion = Instantiate(smallExplosion, transform.position, transform.rotation);
        }
    }
}

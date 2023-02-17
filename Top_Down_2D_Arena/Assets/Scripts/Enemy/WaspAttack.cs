using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class WaspAttack : MonoBehaviour
{
    private GameObject player;
    private Health health;
    private string playerTag = "Player";

    void Start()
    {
        player = GameObject.FindGameObjectWithTag(playerTag);
        health = GetComponent<Health>();
    }

    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.CompareTag(playerTag))
        {
            player.GetComponent<Health>().TakeDamage(10);
            health.TakeDamage(health.currentHealth);
        }
    }
}

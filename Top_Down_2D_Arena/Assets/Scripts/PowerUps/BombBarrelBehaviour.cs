using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BombBarrelBehaviour : MonoBehaviour
{
    [SerializeField] private GameObject bigExplosionPrefab;

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.CompareTag("Enemy"))
        {
            Instantiate(bigExplosionPrefab, transform.position, Quaternion.identity);
            Destroy(gameObject);
        }
    }
}

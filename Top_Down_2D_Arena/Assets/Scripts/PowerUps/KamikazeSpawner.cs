using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class KamikazeSpawner : MonoBehaviour
{
    [SerializeField] private GameObject kamikazePrefab;
    [SerializeField] private GameObject explosionPrefab;
    [SerializeField] private float drivingSpeed = 5f;
    [SerializeField] private float minY = -5f;
    [SerializeField] private float maxY = 5f;
    [SerializeField] private float minX = -5f;
    [SerializeField] private float maxX = 5f;

    private void Start()
    {
        InvokeRepeating(nameof(SpawnKamikaze), 2f, 2f);
    }

    private void SpawnKamikaze()
    {
        // Choose a random Y position outside the screen
        float randomY = Random.Range(minY - 1f, maxY + 1f);
        Vector2 spawnPosition = new Vector2(maxX + 10f, randomY);

        // Instantiate the kamikaze car
        GameObject kamikazeCar = Instantiate(kamikazePrefab, spawnPosition, Quaternion.identity);

        // Set the driving direction
        Vector2 direction = Vector2.left;

        // Set the initial velocity
        Rigidbody2D rb = kamikazeCar.GetComponent<Rigidbody2D>();
        rb.velocity = direction * drivingSpeed;
    }
}

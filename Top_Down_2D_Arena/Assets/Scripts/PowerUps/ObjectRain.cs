using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ObjectRain : BasePowerUp
{
    [SerializeField] private GameObject fallingObjectPrefab;
    [SerializeField] private GameObject explosionPrefab;
    [SerializeField] private float fallSpeed = 5f;
    [SerializeField] private float minY = -5f;
    [SerializeField] private float maxY = 5f;
    [SerializeField] private float minX = -5f;
    [SerializeField] private float maxX = 5f;

    private void Start()
    {
        InvokeRepeating(nameof(SpawnFallingObject), 2f, 2f);
    }

    private void SpawnFallingObject()
    {
        // Choose a random X position outside the screen
        float randomX = Random.Range(minX - 1f, maxX + 1f);
        Vector2 spawnPosition = new Vector2(randomX, maxY + 10f);

        // Instantiate the falling object
        GameObject fallingObject = Instantiate(fallingObjectPrefab, spawnPosition, Quaternion.identity);

        // Set the falling direction
        Vector2 direction = Vector2.down;

        // Set the initial velocity
        Rigidbody2D rb = fallingObject.GetComponent<Rigidbody2D>();
        rb.velocity = direction * fallSpeed;

        // Stop the object at a random position
        float randomStopX = Random.Range(minX, maxX);
        float randomStopY = Random.Range(minY, maxY);
        Vector2 stopPosition = new Vector2(randomStopX, randomStopY);
        StartCoroutine(StopFallingObject(rb, stopPosition, fallingObject));
    }

    private IEnumerator StopFallingObject(Rigidbody2D rb, Vector2 stopPosition, GameObject fallingObject)
    {
        while (rb)
        {
            if (rb.velocity.y < 0f && rb.position.y <= stopPosition.y)
            {
                // Stop the object
                rb.velocity = Vector2.zero;
                rb.position = stopPosition;

                PlaySfx("explosion");
                Instantiate(explosionPrefab, fallingObject.transform.position, Quaternion.identity);
                Destroy(rb.gameObject);

                yield break;
            }
            yield return null;
        }
    }
}

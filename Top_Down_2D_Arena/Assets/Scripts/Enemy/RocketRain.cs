using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RocketRain : MonoBehaviour
{
    public GameObject rocketPrefab;
    public GameObject explosionPrefab;
    public float fallDuration = 2f;
    public float timeBetweenRockets = 1f;

    private bool isRaining = false;

    public void StartRain()
    {
        if (!isRaining)
        {
            isRaining = true;
            StartCoroutine(Rain());
        }
    }

    public void StopRain()
    {
        isRaining = false;
    }

    private IEnumerator Rain()
    {
        while (isRaining)
        {
            // Spawn rockets
            for (int i = 0; i < 5; i++)
            {
                GameObject rocket = Instantiate(rocketPrefab, GetRandomPosition(), Quaternion.identity);
                RocketProjectile rocketProjectile = rocket.GetComponent<RocketProjectile>();
                if (rocketProjectile != null)
                {
                    rocketProjectile.SetOwner(gameObject);
                }
            }

            // Wait before spawning next set of rockets
            yield return new WaitForSeconds(timeBetweenRockets);
        }
    }

    private Vector3 GetRandomPosition()
    {
        Vector3 randomPosition = new Vector3(Random.Range(-10f, 10f), Random.Range(-10f, 10f), 0f);
        return randomPosition;
    }
}

public class RocketProjectile : MonoBehaviour
{
    public float speed = 10f;
    public float fallDuration = 2f;
    public GameObject explosionPrefab;

    private bool isFalling = false;
    private float fallStartTime;

    private GameObject owner;

    public void SetOwner(GameObject owner)
    {
        this.owner = owner;
    }

    private void Update()
    {
        if (isFalling)
        {
            // Calculate current fall progress
            float progress = (Time.time - fallStartTime) / fallDuration;
            if (progress > 1f)
            {
                // Rocket has hit the ground, explode and destroy self
                Instantiate(explosionPrefab, transform.position, Quaternion.identity);
                Destroy(gameObject);
            }
            else
            {
                // Move rocket downward
                transform.Translate(Vector3.down * speed * Time.deltaTime);
            }
        }
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (isFalling && collision.gameObject != owner)
        {
            // Rocket has hit something, explode and destroy self
            Instantiate(explosionPrefab, transform.position, Quaternion.identity);
            Destroy(gameObject);
        }
    }

    public void StartFalling()
    {
        isFalling = true;
        fallStartTime = Time.time;
    }
}

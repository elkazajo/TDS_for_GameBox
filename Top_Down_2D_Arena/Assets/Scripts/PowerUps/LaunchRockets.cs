using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LaunchRockets : MonoBehaviour
{
    [SerializeField] private GameObject rocketPrefab;    
    [SerializeField] private float shootInterval = 2f;

    private Transform playerTransform;

    private void Start()
    {
        playerTransform = GameObject.FindGameObjectWithTag("Player").transform;
        InvokeRepeating(nameof(ShootRocket), shootInterval, shootInterval);
    }

    private void ShootRocket()
    {
        Vector3 shootDirection = Random.insideUnitCircle.normalized;
        Vector2 spawnPosition = playerTransform.position + shootDirection * 0.5f;

        GameObject rocket = Instantiate(rocketPrefab, spawnPosition, Quaternion.Euler(shootDirection));

        rocket.GetComponent<Rigidbody2D>().velocity = shootDirection * 10f;
    }

    
}

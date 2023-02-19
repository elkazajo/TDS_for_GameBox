using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyShooting : MonoBehaviour
{
    [SerializeField] private GameObject bulletPrefab;
    [SerializeField] private GameObject muzzleFlash;
    [SerializeField] private float bulletSpeed = 3f;
    [SerializeField] private float shootingInterval = 5f;

    private Transform playerTransform;
    private Transform parentTransform;
    private float lastShotTime = 0f;
    private EnemyAI enemyAI;

    void Start()
    {
        playerTransform = GameObject.FindGameObjectWithTag("Player").transform;
        parentTransform = GetComponentInParent<Transform>();
        enemyAI = GetComponentInParent<EnemyAI>();
    }

    void Update()
    {
        if (enemyAI.isShooting)
        {
            Vector2 direction = (playerTransform.position - transform.position).normalized;

            if (Time.time - lastShotTime > shootingInterval)
            {
                muzzleFlash.SetActive(true);
                GameObject bullet = Instantiate(bulletPrefab, transform.position, Quaternion.identity);
                bullet.GetComponent<Rigidbody2D>().velocity = direction * bulletSpeed;

                lastShotTime = Time.time;
            }
        }
    }
}

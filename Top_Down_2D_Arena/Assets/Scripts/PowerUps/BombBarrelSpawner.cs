using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BombBarrelSpawner : MonoBehaviour
{
    [SerializeField] private GameObject bombBarrel;
    [SerializeField] private GameObject smokeEffect;
    [SerializeField] private float spawnInterval = 2f;

    private Vector2 spawnPosition;

    // Define the camera and screen dimensions
    private Camera mainCamera;
    private float cameraHeight;
    private float cameraWidth;

    private void Start()
    {
        InvokeRepeating(nameof(SpawnObject), 0f, spawnInterval);
    }

    private void SpawnObject()
    {
        mainCamera = Camera.main;
        cameraHeight = mainCamera.orthographicSize;
        cameraWidth = cameraHeight * mainCamera.aspect;

        // Generate a random position on the visible part of the screen
        float randomX = Random.Range(-cameraWidth, cameraWidth);
        float randomY = Random.Range(-cameraHeight, cameraHeight);
        spawnPosition = new Vector2(randomX, randomY);

        Instantiate(bombBarrel, spawnPosition, Quaternion.identity);
        Instantiate(smokeEffect, spawnPosition, Quaternion.identity);
    }
}

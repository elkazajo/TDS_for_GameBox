using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemySpawner : MonoBehaviour
{
    [SerializeField] private GameObject[] enemyPrefab;

    private GameObject player;
    private Vector2 screenBounds;

    private float spawnInterval = 2f;
    private int currentEnemies = 0;    
    private bool isPlayerAlive;
    private string playerTag = "Player";        

    void Start()
    {
        screenBounds = Camera.main.ScreenToWorldPoint(new Vector3(Screen.width, Screen.height, Camera.main.transform.position.z));
        player = GameObject.FindGameObjectWithTag(playerTag);
        isPlayerAlive = player.GetComponent<Health>().isAlive;
        StartCoroutine(SpawnEnemies());
    }

    IEnumerator SpawnEnemies()
    {
        while (isPlayerAlive)
        {
            float spawnDistance = Mathf.Max(screenBounds.x, screenBounds.y) + 10f;
            Vector2 spawnDirection = Random.insideUnitCircle.normalized;
            Vector2 spawnPosition = spawnDirection * spawnDistance;

            Instantiate(enemyPrefab[0], spawnPosition, Quaternion.identity);
            
            currentEnemies++;
            yield return new WaitForSeconds(spawnInterval);
        }
    }
}

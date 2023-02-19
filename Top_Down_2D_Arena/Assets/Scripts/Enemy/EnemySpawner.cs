using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemySpawner : MonoBehaviour
{
    [SerializeField] private GameObject[] enemyPrefab;

    private GameObject player;
    private Vector2 screenBounds;
    Vector2 spawnPosition;
    int waspThreshold = 50;
    int centipedeHeadThreshold = 100;
    int hornetThreshold = 150;
    int scarabThreshold = 200;
    private int numEnemies = 0;

    private float spawnInterval = 2f;  
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
            spawnPosition = spawnDirection * spawnDistance;

            InvokeRepeating("InstantiateWasp", 0f, 2);
            yield return new WaitForSeconds(spawnInterval);
        }
    }

    void InstantiateWasp()
    {
        GameObject wasp = Instantiate(enemyPrefab[0], spawnPosition, Quaternion.identity);

        numEnemies++;

        if (numEnemies % waspThreshold == 0)
        {
            CancelInvoke("InstantiateWasp");
            InvokeRepeating("InstantiateCentipedeHead", 0f, 2);
        }
    }

    void InstantiateCentipedeHead()
    {
        GameObject centipedeHead = Instantiate(enemyPrefab[1], spawnPosition, Quaternion.identity);
        numEnemies++;

        if (numEnemies % centipedeHeadThreshold == 0)
        {
            CancelInvoke("InstantiateCentipedeHead");
            InvokeRepeating("InstantiateHornet", 0f, 2);
        }
    }

    void InstantiateHornet()
    {
        GameObject hornet = Instantiate(enemyPrefab[2], spawnPosition, Quaternion.identity);
        numEnemies++;

        if (numEnemies % hornetThreshold == 0)
        {
            CancelInvoke("InstantiateHornet");
            InvokeRepeating("InstantiateScarab", 0f, 2);
        }
    }

    void InstantiateScarab()
    {
        GameObject scarab = Instantiate(enemyPrefab[3], spawnPosition, Quaternion.identity);
        numEnemies++;

        if (numEnemies % scarabThreshold == 0)
        {
            CancelInvoke("InstantiateScarab");
            InvokeRepeating("InstantiateSpider", 0f, 2);
        }
    }

    void InstantiateSpider()
    {
        GameObject spider = Instantiate(enemyPrefab[4], spawnPosition, Quaternion.identity);
        numEnemies++;
    }
}

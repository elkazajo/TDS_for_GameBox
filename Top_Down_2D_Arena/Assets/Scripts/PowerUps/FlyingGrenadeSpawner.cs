using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FlyingGrenadeSpawner : MonoBehaviour
{
    [SerializeField] private GameObject flyingGrenadePrefab;

    private Transform playerTransform;
    private string playerTag = "Player";

    private void Start()
    {
        playerTransform = GameObject.FindGameObjectWithTag(playerTag).transform;
        GameObject flyingGrenade = Instantiate(flyingGrenadePrefab, playerTransform.position, Quaternion.identity);
    }
}

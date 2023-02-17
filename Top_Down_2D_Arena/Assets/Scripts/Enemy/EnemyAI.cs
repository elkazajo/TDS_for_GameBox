using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyAI : MonoBehaviour
{    
    [SerializeField] private float moveSpeed = 3f;
    [SerializeField] private float attackDistance = 1f;

    private GameObject player;
    private Vector3 direction;

    private void Start()
    {
        player = GameObject.Find("Player");
    }

    void Update()
    {
        if (player != null)
        {
           direction = (player.transform.position - transform.position).normalized;
        }            

        if(player != null && Vector3.Distance(player.transform.position, transform.position) > attackDistance)
        {
            transform.position += direction * moveSpeed * Time.deltaTime;

            if (direction.x > 0)
            {
                transform.localScale = new Vector3(1, 1, 1);
            }
            else
            {
                transform.localScale = new Vector3(-1, 1, 1);
            }
        }        
    }
}

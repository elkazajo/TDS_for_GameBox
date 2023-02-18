using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerMovementConfiner : MonoBehaviour
{
    [SerializeField] private GameObject playerMovementConfiner;

    private void FixedUpdate()
    {
        if (!playerMovementConfiner.GetComponent<Collider2D>().bounds.Contains(transform.position))
        {
            Vector3 clampedPosition = playerMovementConfiner.GetComponent<Collider2D>().bounds.ClosestPoint(transform.position);
            transform.position = clampedPosition;
        }
    }
}

using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PowerUpsManager : MonoBehaviour
{
    [SerializeField] private GameObject[] powerUpSpawner;
    [SerializeField] private DamageDealer[] damageDealer;

    private GameObject powerUpClone;

    public void ManagePowerUp(int powerUpIndex)
    {
        if (powerUpClone == null)
        {
            GameObject powerUpClone = Instantiate(powerUpSpawner[powerUpIndex], transform.position, Quaternion.identity);
        }
        else
        {
            damageDealer[powerUpIndex].damageAmount += 10;
        }
    }
}

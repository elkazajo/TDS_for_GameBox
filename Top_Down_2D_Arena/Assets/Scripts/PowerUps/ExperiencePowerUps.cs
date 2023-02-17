using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ExperiencePowerUps : MonoBehaviour
{
    [SerializeField] private UI ui;
    [SerializeField] GameObject[] powerUp;

    private int currentExperience;
    private int maxExperience = 500;
    private int nextUpgrade = 600;


    void Start()
    {
       
    }

    void Update()
    {
        currentExperience = ui.totalExperience;

        if(currentExperience >= maxExperience)
        {
            Instantiate(powerUp[0], transform.position, Quaternion.identity);
            maxExperience += nextUpgrade;
        }        
    }
}

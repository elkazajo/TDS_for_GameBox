using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CollectableExperience : MonoBehaviour
{
    private UI ui;    
    private int experience;

    private void Start()
    {
        ui = FindObjectOfType<UI>();
    }

    public void SetExperience(int newExperience)
    {
        experience = newExperience;
    }

    public int GetExperience()
    {
        return experience;
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.CompareTag("Player"))
        {
            ui.totalExperience += experience;
            Destroy(gameObject);
        }
    }
}

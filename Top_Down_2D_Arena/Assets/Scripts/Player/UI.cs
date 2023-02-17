using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class UI : MonoBehaviour
{
    [SerializeField] private Text hp;
    [SerializeField] private Text exp;

    private GameObject player;
    private Health health;
    public int totalExperience;
        
    void Start()
    {
        player = GameObject.FindGameObjectWithTag("Player");
        health = player.GetComponent<Health>();
    }
        
    void Update()
    {
        hp.text = $"HP: {health.currentHealth}";
        exp.text = $"Exp: {totalExperience}";
    }
}

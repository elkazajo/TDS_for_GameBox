using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class UI : MonoBehaviour
{
    [SerializeField] private Text hp;
    [SerializeField] private Text exp;
    [SerializeField] private Text timer;

    private GameObject player;
    private Health health;
    private Timer currentTimer;
    public int totalExperience;
        
    void Start()
    {
        player = GameObject.FindGameObjectWithTag("Player");
        health = player.GetComponent<Health>();
        currentTimer = FindObjectOfType<Timer>();
    }
        
    void Update()
    {
        hp.text = $"HP: {health.currentHealth}";
        exp.text = $"Exp: {totalExperience}";
        timer.text = $"Time {(int)currentTimer.time}";
    }
}

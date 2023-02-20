using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class UiManager : MonoBehaviour
{
    [SerializeField] private Canvas gameOverCanvas;
    
    [SerializeField] private Text totalExperienceGained;
    [SerializeField] private Text totalTime;
    [SerializeField] private Text hp;
    [SerializeField] private Text exp;
    [SerializeField] private Text timer;

    private GameObject player;
    private Health playerHealth;
    private Timer currentTimer;
    public int totalExperience;
        
    void Start()
    {
        player = GameObject.FindGameObjectWithTag("Player");
        gameOverCanvas.enabled = false;
        playerHealth = player.GetComponent<Health>();
        currentTimer = FindObjectOfType<Timer>();
    }
        
    void Update()
    {
        hp.text = $"HP: {playerHealth.currentHealth}";
        exp.text = $"Exp: {totalExperience}";
        timer.text = $"Time {(int)currentTimer.time}";

        if (!playerHealth.isAlive)
        {
            gameOverCanvas.enabled = true;

            Time.timeScale = 0;

            totalExperienceGained.text = $"Total Experience points: {totalExperience}";
            totalTime.text = $"Survived for {(int)currentTimer.time} Seconds";
        }
    }
}

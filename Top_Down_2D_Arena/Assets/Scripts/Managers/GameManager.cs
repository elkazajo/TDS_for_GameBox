using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class GameManager : MonoBehaviour
{
    [SerializeField] private Canvas powerUpMenuCanvas;
    [SerializeField] private Canvas gameOverCanvas;
    [SerializeField] private Health playerHealth;
    [SerializeField] private Text totalExperience;
    [SerializeField] private Text totalTime;

    UI ui;
    Timer timer;

    private void Awake()
    {
        powerUpMenuCanvas.enabled = false;
        gameOverCanvas.enabled = false;
        ui = FindObjectOfType<UI>();
        timer = FindObjectOfType<Timer>();
        Time.timeScale = 1;
    }

    public void UnPauseTheGame()
    {
        Time.timeScale = 1;
    }

    private void Update()
    {
        if (!playerHealth.isAlive)
        {
            gameOverCanvas.enabled = true;

            Time.timeScale = 0;

            totalExperience.text = $"Total Experience Gained {ui.totalExperience}";
            totalTime.text = $"Survived for {(int)timer.time} Seconds";
        }
    }
}

using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class GameManager : MonoBehaviour
{
    [SerializeField] private Canvas powerUpMenuCanvas;

    private void Awake()
    {
        powerUpMenuCanvas.enabled = false;
        Time.timeScale = 1;
    }

    public void UnPauseTheGame()
    {
        Time.timeScale = 1;
    }
}

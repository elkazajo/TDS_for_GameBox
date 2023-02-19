using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameManager : MonoBehaviour
{
    [SerializeField] private Canvas powerUpMenuCanvas;

    private void Awake()
    {
        powerUpMenuCanvas.enabled = false;
    }

    public void UnPauseTheGame()
    {
        Time.timeScale = 1;
    }
}

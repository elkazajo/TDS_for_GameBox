using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BasePowerUp : MonoBehaviour
{
    private AudioManager audioManager;

    void Awake()
    {
        audioManager = FindObjectOfType<AudioManager>();
    }
    
    public void PlaySfx(string name)
    {
        audioManager.Play(name);
    }
}

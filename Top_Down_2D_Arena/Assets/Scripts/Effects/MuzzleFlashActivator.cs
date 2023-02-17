using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MuzzleFlashActivator : MonoBehaviour
{
    [SerializeField] private GameObject muzzleFlash;
    [SerializeField] private GameObject muzzleFlash2;

    private string animName = "MuzzleFlash";
    private PlayerController playerController;
    

    void Start()
    {
        playerController = FindObjectOfType<PlayerController>();
    }

    // Update is called once per frame
    void Update()
    {
        if (!playerController.isDead && Input.GetButtonDown("Fire1"))
        {
            if (!playerController.wasShot)
            {
                muzzleFlash.SetActive(true);
                

            }
            else
            {
                muzzleFlash2.SetActive(true);
            }

        }
    }
}

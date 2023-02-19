using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerAnimationManager : MonoBehaviour
{
    const string IdleAnim = "Idle";    
    const string RunAnim = "Run";
    const string ShootAnim = "Shoot";

    private Animator animator;

    private string currentAnimaton;

    void Start()
    {
        animator = GetComponent<Animator>();
    }

    void ChangeAnimationState(string newAnimation)
    {
        if (currentAnimaton == newAnimation) return;

        animator.Play(newAnimation);
        currentAnimaton = newAnimation;
    }

    void Update()
    {
        if (Input.GetKey(KeyCode.W) || Input.GetKey(KeyCode.A) || Input.GetKey(KeyCode.S) || Input.GetKey(KeyCode.D))
        {
            ChangeAnimationState(RunAnim);
        }
        else
        {
            ChangeAnimationState(IdleAnim);
        }

        if (Input.GetButtonDown("Fire1"))
        {
            ChangeAnimationState(ShootAnim);
        }
    }
}

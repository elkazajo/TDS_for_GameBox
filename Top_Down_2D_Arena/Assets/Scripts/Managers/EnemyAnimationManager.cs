using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyAnimationManager : MonoBehaviour
{
    const string RunAnim = "Run";
    const string ShootAnim = "Shoot";

    private Animator animator;
    private EnemyAI enemyAI;

    private string currentAnimaton;

    void Start()
    {
        animator = GetComponent<Animator>();
        enemyAI = GetComponent<EnemyAI>();
    }

    void ChangeAnimationState(string newAnimation)
    {
        if (currentAnimaton == newAnimation) return;

        animator.Play(newAnimation);
        currentAnimaton = newAnimation;
    }

    void Update()
    {
        if (enemyAI.isRunning)
        {
            ChangeAnimationState(RunAnim);
        }

        if (enemyAI.isShooting)
        {
            ChangeAnimationState(ShootAnim);
        }
    }
}

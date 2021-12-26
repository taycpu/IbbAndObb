using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerAnimator : PlayerComponent
{
    private static readonly int Horizontal = Animator.StringToHash("Horizontal");
    private static readonly int Idle = Animator.StringToHash("Idle");
    private static readonly int Vertical = Animator.StringToHash("Vertical");


    [SerializeField] private PlayerMovement movement;
    [SerializeField] private Animator animator;

    public override void Tick()
    {
        animator.SetFloat(Horizontal, movement.Horizontal);
        animator.SetFloat(Vertical, movement.Vertical);
    }
}
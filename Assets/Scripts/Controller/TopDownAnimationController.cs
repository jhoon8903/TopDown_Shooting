using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TopDownAnimationController : TopDownAnimation
{
    private static readonly int IsWalking = Animator.StringToHash("IsWalking");
    private static readonly int Attack = Animator.StringToHash("Attack");
    private static readonly int IsHit = Animator.StringToHash("IsHit");

    protected override void Awake()
    {
        base.Awake();
    }

    private void Start()
    {
        Controller.OnAttackEvent += Attacking;
        Controller.OnMoveEvent += Move;
    }

    private void Move(Vector2 obj)
    {
        Animator.SetBool(IsWalking, obj.magnitude > 0.5f);
    }

    private void Attacking(AttackScriptableObject obj)
    {
        Animator.SetTrigger(Attack);
    }

    private void Hit()
    {
        Animator.SetBool(IsHit, true);
    }

    private void InvincibilityEnd()
    {
        Animator.SetBool(IsHit, false);
    }
} 

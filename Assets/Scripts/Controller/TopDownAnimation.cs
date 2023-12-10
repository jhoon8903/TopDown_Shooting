using System;
using System.Collections;
using System.Collections.Generic;
using Controller;
using UnityEngine;

public class TopDownAnimation : MonoBehaviour
{
    protected Animator Animator;
    protected InputEvents Controller;

    protected virtual void Awake()
    {
        Animator = GetComponentInChildren<Animator>();
        Controller = GetComponent<InputEvents>();
    }
}

using System;
using System.Collections;
using System.Collections.Generic;
using Controller;
using UnityEngine;

public class TopDownEnemyController :  InputEvents
{
    private GameManager _gameManager;
    protected Transform ClosetsTarget { get; private set; }

    protected override void Awake()
    {
        base.Awake();
    }

    protected override void Start()
    {
        base.Start();
        _gameManager = GameManager.Instance;
        ClosetsTarget = _gameManager.Player;
    }

    protected virtual void FixedUpdate()
    {
        
    }

    protected float DistanceToTarget()
    {
        return Vector3.Distance(transform.position, ClosetsTarget.position);
    }

    protected Vector2 DirectionToTarget()
    {
        return (ClosetsTarget.position - transform.position).normalized;
    }
}

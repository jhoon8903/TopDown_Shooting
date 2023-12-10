using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UIElements;

public class TopDownContactEnemyController : TopDownEnemyController
{
    [SerializeField] [Range(0f, 100f)] private float followRange;
    [SerializeField] private string targetTag = "Player";
    [SerializeField] private SpriteRenderer characterRenderer;
    private bool _isColliderWithTarget;


    protected override void Start()
    {
        base.Start();
    }

    protected override void FixedUpdate()
    {
        base.FixedUpdate();

        if (DistanceToTarget() < followRange)
        {
            var direction = DirectionToTarget();
            CallMoveEvent(direction);
            Rotate(direction);
        }
    }

    private void Rotate(Vector2 direction)
    {
        float rotZ = Mathf.Atan2(direction.y, direction.x) * Mathf.Rad2Deg;
        characterRenderer.flipX = Mathf.Abs(rotZ) > 90f;
    }
}

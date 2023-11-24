using System;
using Controller;
using UnityEngine;

namespace Entities
{
    public class AimEntities : MonoBehaviour
    {
        [SerializeField] private SpriteRenderer arm1;
        [SerializeField] private Transform armPivot;
        [SerializeField] private SpriteRenderer character; 
        private InputEvents _controller;

        private void Awake()
        {
            _controller = GetComponent<InputEvents>();
        }

        private void Start()
        {
            _controller.OnLookEvent += OnAim;
        }

        private void OnAim(Vector2 aimDirection)
        {
            RotateArm(aimDirection);
        }

        private void RotateArm(Vector2 aimDirection)
        {
            float rotate = Mathf.Atan2(aimDirection.y, aimDirection.x) * Mathf.Rad2Deg;
            arm1.flipY = Mathf.Abs(rotate) > 90f;
            character.flipX = arm1.flipY;
            armPivot.rotation = Quaternion.Euler(0,0,rotate);
        }
    }
}

using System;
using UnityEngine;
using UnityEngine.InputSystem;

namespace Controller
{
    // Observer Pattern 
    // Events Subscribe Design
    public class PlayerInput : InputEvents
    {
        private Camera _camera;

        protected  override void Awake()
        {    
            base.Awake();
            _camera = Camera.main;     // Scene에 존재하는 "Main Camera" 오브젝트
        }

        public void OnMove(InputValue value)
        {
            Vector2 moveInput = value.Get<Vector2>().normalized;
            CallMoveEvent(moveInput);
        }

        public void OnLook(InputValue value)
        {
            Vector2 lookInput = value.Get<Vector2>();
            Vector2 worldPos = _camera.ScreenToWorldPoint(lookInput);
            lookInput = (worldPos - (Vector2)transform.position).normalized;
            if (lookInput.magnitude >= 0.9f)
            {
                CallLookEvent(lookInput);
            }
        }

        public void OnFire(InputValue value)
        {
            IsAttack = value.isPressed;
        }
    }
}

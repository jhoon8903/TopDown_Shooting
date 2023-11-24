using System;
using Controller;
using UnityEngine;

namespace Entities
{
    public class MovementEntities : MonoBehaviour
    {
        private InputEvents _inputEvents;
        private Vector2 _moveDirection;
        private Rigidbody2D _rigidbody2D;

        private void Awake()
        {
            _inputEvents = GetComponent<InputEvents>();
            _rigidbody2D = GetComponent<Rigidbody2D>();
        }

        private void Start()
        {
            _inputEvents.OnMoveEvent += Move;
        }

        private void FixedUpdate()
        {
            if (_inputEvents != null)
            {
                ApplyMovement(_moveDirection);
            }
        }

        private void Move(Vector2 direction)
        {
            _moveDirection = direction;
        }

        private void ApplyMovement(Vector2 direction)
        {
            direction = direction * 5;
            _rigidbody2D.velocity = direction;
        }
    }
}

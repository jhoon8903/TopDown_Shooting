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
        private CharacterStatsHandler _characterStatsHandler;

        private void Awake()
        {
            _inputEvents = GetComponent<InputEvents>();
            _rigidbody2D = GetComponent<Rigidbody2D>();
            _characterStatsHandler = GetComponent<CharacterStatsHandler>();
    
        }

        private void Start()
        {
            _inputEvents.OnMoveEvent += Move; 
            if (gameObject.CompareTag("Goblin"))
            {
                Debug.Log($"꼬부꼬부 OnMove 이벤트 호출!");
            }
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
            if (gameObject.CompareTag("Goblin"))
            {
                Debug.Log($"꼬부꼬부 Move After 디렉션 {direction}");
            }
            _moveDirection = direction;
        }

        private void ApplyMovement(Vector2 direction)
        {
            direction *= _characterStatsHandler.CurrentStates.speed;
            if (gameObject.CompareTag("Goblin"))
            {
                Debug.Log($"꼬부꼬부 ApplyMove Before디렉션 {direction}");
            }
            _rigidbody2D.velocity = direction;
        }
    }
}

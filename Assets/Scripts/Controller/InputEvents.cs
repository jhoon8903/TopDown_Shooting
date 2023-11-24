using System;
using UnityEngine;

namespace Controller
{
    public class InputEvents : MonoBehaviour
    {
        public event Action<Vector2> OnMoveEvent;
        public event Action<Vector2> OnLookEvent;
        public event Action OnAttackEvent;
        private float _attackTerm = float.MaxValue;
        protected bool IsAttack { get; set; }

        protected virtual void Update()
        {
            AttackDelay();
        }

        private void AttackDelay()
        {
            if (_attackTerm <= 0.2f)
            {
                _attackTerm += Time.deltaTime;
            }
            
            if (IsAttack && _attackTerm > 0.2f)
            {
                _attackTerm = 0;
                CallAttackEvent();
            }
        }

        protected void CallMoveEvent(Vector2 direction)
        {
            OnMoveEvent?.Invoke(direction);
        }

        protected void CallLookEvent(Vector2 direction)
        {
            OnLookEvent?.Invoke(direction);
        }

        protected void CallAttackEvent()
        {
            OnAttackEvent?.Invoke();
        }
    }
}

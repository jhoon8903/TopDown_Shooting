using System;
using UnityEngine;

namespace Controller
{
    public class InputEvents : MonoBehaviour
    {
        public event Action<Vector2> OnMoveEvent;
        public event Action<Vector2> OnLookEvent;
        public event Action<AttackScriptableObject> OnAttackEvent;
        private float _attackTerm = float.MaxValue;
        protected bool IsAttack { get; set; }
        protected CharacterStatsHandler CharacterStatsHandler;
        protected float Delay;
        protected AttackScriptableObject attackSO;

        protected virtual void Awake()
        {
        }

        protected virtual void Start()
        {
            CharacterStatsHandler = GetComponent<CharacterStatsHandler>();
            attackSO = CharacterStatsHandler.CurrentStates.attackSo;
            Delay = CharacterStatsHandler.CurrentStates.attackSo.delay;
        }

        protected virtual void Update()
        {
            AttackDelay();
        }

        private void AttackDelay()
        {
            if (attackSO == null) return;

            if (_attackTerm <= Delay)
            {
                _attackTerm += Time.deltaTime;
            }
            
            if (IsAttack && _attackTerm > Delay)
            {
                _attackTerm = 0;
                CallAttackEvent(attackSO);
            }
        }

        protected void CallMoveEvent(Vector2 direction)
        {           
            OnMoveEvent?.Invoke(direction);
            if (gameObject.CompareTag("Goblin"))
            {
                Debug.Log($"꼬부꼬부 Call Move Invoke 디렉션 {direction}");
            }
        }

        protected void CallLookEvent(Vector2 direction)
        {
            OnLookEvent?.Invoke(direction);
        }

        protected void CallAttackEvent(AttackScriptableObject attackScriptableObject)
        {
            OnAttackEvent?.Invoke(attackScriptableObject);
        }
    }
}

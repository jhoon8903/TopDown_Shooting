using System;
using Controller;
using UnityEngine;
using UnityEngine.Serialization;

namespace Entities
{
    public class ShootEntities : MonoBehaviour
    {
        private InputEvents _controller;
       [SerializeField] private Transform arrowTransform;
        private Vector2 _arrowDirection = Vector2.right;
        public GameObject arrow;

        private void Awake()
        {
            _controller = GetComponent<InputEvents>();
        }

        private void Start()
        {
            _controller.OnAttackEvent += OnShoot;
            _controller.OnLookEvent += OnAim;
        }

        private void OnAim(Vector2 aimDirection)
        {
            _arrowDirection = aimDirection;
        }

        private void OnShoot()
        {
            CreateProjectile();
        }

        private void CreateProjectile()
        {
            Instantiate(arrow, arrowTransform.position, Quaternion.identity);
        }
    }
}

using System;
using Controller;
using UnityEngine;
using UnityEngine.Serialization;
using UnityEngine.UIElements;
using Random = UnityEngine.Random;

namespace Entities
{
    public class ShootEntities : MonoBehaviour
    {
        private ProjectileManager _projectileManager;
        private InputEvents _controller;
       [SerializeField] private Transform arrowTransform;
        private Vector2 _arrowDirection = Vector2.right;


        private void Awake()
        {
            _controller = GetComponent<InputEvents>();
        }

        private void Start()
        {
            _projectileManager = ProjectileManager.Instance;
            _controller.OnAttackEvent += OnShoot;
            _controller.OnLookEvent += OnAim;
        }

        private void OnAim(Vector2 aimDirection)
        {
            _arrowDirection = aimDirection;
        }

        private void OnShoot(AttackScriptableObject attackScriptableObject)
        {
            RangedAttackData rangedAttackData = attackScriptableObject as RangedAttackData;
            if (rangedAttackData == null) return;
            float projectilesAngleSpace = rangedAttackData.multipleProjectileAngel;
            int numberOfProjectilesPerShot = rangedAttackData.numberOfProjectilesPerShot;
            float minAngle = -(numberOfProjectilesPerShot / 2f) * projectilesAngleSpace + 0.5f * projectilesAngleSpace;
            for (int i = 0; i < numberOfProjectilesPerShot; i++)
            {
                float angle = minAngle + projectilesAngleSpace * i;
                float randomSpread = Random.Range(-rangedAttackData.spread, rangedAttackData.spread);
                angle += randomSpread;
                CreateProjectile(rangedAttackData, angle);
            }
        }

        private void CreateProjectile(RangedAttackData rangedAttackData, float angle)
        {
            _projectileManager.ShootBullet(
                arrowTransform.position, 
                RotateVector2(_arrowDirection, angle), 
                rangedAttackData);
        }

        private Vector2 RotateVector2(Vector2 v, float degree)
        {
            return Quaternion.Euler(0, 0, degree) * v;
        }
    }
}

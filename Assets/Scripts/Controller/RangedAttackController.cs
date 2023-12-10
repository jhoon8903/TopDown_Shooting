using UnityEngine;
using UnityEngine.Serialization;

public class RangedAttackController : MonoBehaviour
{
   [SerializeField] private LayerMask levelCollisionLayerMask;
   private float _currentDuration;
   private Vector2 _direction;
   private bool _isReady;
   private RangedAttackData _attackData;

   private Rigidbody2D _rigidBody2D;
   private SpriteRenderer _spriteRenderer;
   private TrailRenderer _trailRenderer;
   private ProjectileManager _projectileManager;
   public bool fxOnDestroy = false;

   private void Awake()
   {
      _rigidBody2D = GetComponent<Rigidbody2D>();
      _spriteRenderer = GetComponentInChildren<SpriteRenderer>();
      _trailRenderer = GetComponent<TrailRenderer>();
   }

   private void Start()
   {
      _projectileManager = ProjectileManager.Instance;
   }

   private void Update()
   {
      if (!_isReady) return;
      _currentDuration += Time.deltaTime;
      if (_currentDuration > _attackData.duration)
      {
         DestroyProjectile(transform.position, false);
      }
      _rigidBody2D.velocity = _direction * _attackData.speed;
   }

   private void OnTriggerEnter2D(Collider2D collision)
   {
      if (levelCollisionLayerMask.value == (levelCollisionLayerMask.value | (1 << collision.gameObject.layer)))
      { 
         DestroyProjectile(collision.ClosestPoint(transform.position) - _direction* 0.2f, fxOnDestroy);
      }
   }

   public void InitializeAttack(Vector2 direction, RangedAttackData attackData, ProjectileManager projectileManager)
   {
      _projectileManager = projectileManager;
      _attackData = attackData;
      _direction = direction;
      _trailRenderer.Clear();
      _currentDuration = 0;
      _spriteRenderer.color = attackData.projectileColor;
      transform.right = _direction;
      _isReady = true;
   }

   private void UpdateProjectileSprite()
   {
      transform.localScale = Vector3.one *_attackData.size;
   }

   private void DestroyProjectile(Vector3 transformPosition, bool createFx)
   {
      if (createFx)
      {

      }
      gameObject.SetActive(false);
   }
}

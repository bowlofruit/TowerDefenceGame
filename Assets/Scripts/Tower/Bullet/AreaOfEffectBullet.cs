using UnityEngine;

namespace TowerDefence
{
    public class AreaOfEffectBullet : Bullet
    {
        [SerializeField] private float _explosionRadius;

        private void OnCollisionEnter2D(Collision2D collision)
        {
            if (collision.gameObject.TryGetComponent(out EnemyDeath enemy))
            {
                Collider2D[] colliders = Physics2D.OverlapCircleAll(transform.position, _explosionRadius);

                foreach (Collider2D collider in colliders)
                {
                    if (collider.gameObject.TryGetComponent(out EnemyDeath nearEnemy))
                    {
                        nearEnemy.TakeDamage(Damage);
                    }
                }

                _killAction.Invoke(this);
                Destroy(gameObject);
            }
        }

        private void OnDrawGizmos()
        {
            Gizmos.color = Color.red;
            Gizmos.DrawWireSphere(transform.position, _explosionRadius);
        }
    }
}
using UnityEngine;

namespace TowerDefence
{
    public class AreaOfEffectBullet : Bullet
    {
        [SerializeField] private float _explosionRadius;

        [SerializeField] private GameObject _areaPrefab;

        private void OnCollisionEnter2D(Collision2D collision)
        {
            if (collision.gameObject.TryGetComponent(out EnemyController enemy))
            {
                Collider2D[] colliders = Physics2D.OverlapCircleAll(transform.position, _explosionRadius);

                foreach (Collider2D collider in colliders)
                {
                    if (collider.gameObject.TryGetComponent(out EnemyController nearEnemy))
                    {
                        nearEnemy.TakeDamage(Damage);
                    }
                }

                if (_isUpgrade)
                {
                    GameObject damageArea = Instantiate(_areaPrefab, transform.position, Quaternion.identity);
                    if (damageArea.TryGetComponent(out DamageArea area))
                    {
                        area.StartLifeTimeArea(3);
                    }
                }
                KillAction.Invoke(this);
            }
        }

        private void OnDrawGizmos()
        {
            Gizmos.color = Color.red;
            Gizmos.DrawWireSphere(transform.position, _explosionRadius);
        }
    }
}
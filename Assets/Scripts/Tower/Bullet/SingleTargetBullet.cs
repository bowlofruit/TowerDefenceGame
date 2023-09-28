using UnityEngine;

namespace TowerDefence
{
    public class SingleTargetBullet : Bullet
    {
        private void OnCollisionEnter2D(Collision2D collision)
        {
            if (collision.gameObject.TryGetComponent(out EnemyDeath enemy))
            {
                enemy.TakeDamage(100);
                _killAction.Invoke(this);
                Destroy(gameObject);
            }
        }
    }
}
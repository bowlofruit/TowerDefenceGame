using UnityEngine;

namespace TowerDefence
{
    public class SingleTargetBullet : Bullet
    {
        [SerializeField] private float _periodicDamageInterval;
        [SerializeField] private float _periodicDamageAmount;
        [SerializeField] private float _periodicDamageRate;

        [SerializeField] SpriteRenderer _bulletSprite;

        private void OnTriggerEnter2D(Collider2D collision)
        {
            if (collision.gameObject.TryGetComponent(out EnemyController enemy))
            {
                enemy.TakeDamage(Damage);

                if (_isUpgrade)
                {
                    enemy.TakePeriodicalDamage(_periodicDamageInterval, _periodicDamageRate, _periodicDamageAmount);
                }
                KillAction.Invoke(this);
            }
        }
    }
}
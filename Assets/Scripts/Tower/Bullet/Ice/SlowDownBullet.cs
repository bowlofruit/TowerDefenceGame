using UnityEngine;

namespace TowerDefence
{
    public class SlowDownBullet : Bullet
    {
        [SerializeField][Range(0.5f, 0.8f)] private float _speedScalingFactor;
        [SerializeField] private int _stopTimer;

        private void OnTriggerEnter2D(Collider2D collision)
        {
            if (collision.gameObject.TryGetComponent(out EnemyController enemy) && collision.gameObject.TryGetComponent(out EnemyMovement movement))
            {
                movement.ChangeSpeed(_speedScalingFactor, _stopTimer);
                enemy.TakeDamage(Damage);

                _animator.SetBool("IsActive", false);
                KillAction.Invoke(this);
            }
        }
    }
}
﻿using UnityEngine;

namespace TowerDefence
{
    public class SlowDownBullet : Bullet
    {
        [SerializeField][Range(0.5f, 0.8f)] private float _speedScalingFactor;
        [SerializeField] private int _stopTimer;

        private void OnCollisionEnter2D(Collision2D collision)
        {
            if (collision.gameObject.TryGetComponent(out EnemyDeath enemy) && collision.gameObject.TryGetComponent(out EnemyMovement movement))
            {
                movement.ChangeSpeed(_speedScalingFactor, _stopTimer);
                enemy.TakeDamage(5);
                _killAction.Invoke(this);
                Destroy(gameObject);
            }
        }
    }
}
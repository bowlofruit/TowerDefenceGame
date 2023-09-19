using System;
using UnityEngine;

namespace TowerDefence
{
    public class Bullet : MonoBehaviour
    {
        [SerializeField] private Rigidbody2D _rb;

        private Action<GameObject> _killAction;
        private int _speed;
        private int _damage;
        private Transform _target;

        public void InitParams(Action<GameObject> killAction, int speed, int damage)
        {
            _killAction = killAction;
            _speed = speed;
            _damage = damage;
        }

        public void SetTarget(Transform target)
        {
            _target = target;
        }

        private void FixedUpdate()
        {
            if (!_target) 
            {
                Destroy(gameObject);
                return;
            }

            Vector2 dir = (_target.position - transform.position).normalized;

            _rb.velocity = dir * _speed * 3;
        }

        private void OnCollisionEnter2D(Collision2D collision)
        {
            if (collision.gameObject.TryGetComponent(out EnemyDeath enemy))
            {
                enemy.TakeDamage(_damage);
                _killAction.Invoke(this.gameObject);
            }
        }
    }
}
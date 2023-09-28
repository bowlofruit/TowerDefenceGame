using System;
using UnityEngine;

namespace TowerDefence
{
    public class Bullet : MonoBehaviour
    {
        [SerializeField] private Rigidbody2D _rb;

        protected Action<Bullet> _killAction;
        private float _speed;
        private int _damage;
        private Transform _target;

        public int Damage { get => _damage; set => _damage = value; }

        public void InitParams(Action<Bullet> killAction, int speed, int damage)
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

            float angle = Mathf.Atan2(dir.y, dir.x) * Mathf.Rad2Deg;
            transform.rotation = Quaternion.Euler(new Vector3(0, 0, angle + -90));

            _rb.velocity = dir * _speed * 3;
        }
    }
}
using System;
using UnityEngine;

namespace TowerDefence
{
    public class Bullet : MonoBehaviour
    {
        [SerializeField] private Rigidbody2D _rb;

        protected Action<Bullet> KillAction { get; set; }
        private float _speed;
        private Transform _target;
        protected bool _isUpgrade;

        public float Damage { get; set; }

        public void Init(Action<Bullet> killAction, float speed, float damage, bool isUpgrade)
        {
            KillAction = killAction;
            _speed = speed;
            Damage = damage;
            _isUpgrade = isUpgrade;
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
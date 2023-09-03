using UnityEngine;

namespace TowerDefence
{
    public class Bullet : MonoBehaviour
    {
        [SerializeField] private Rigidbody2D _rb;

        private int _speed;
        private int _damage;
        private Transform _target;

        public void SetSpeedAndDamage(int speed, int damage)
        {
            _speed = speed;
            _damage = damage;
        }

        public void SetTarget(Transform target)
        {
            _target = target;
        }

        private void FixedUpdate()
        {
            if (!_target) return;

            Vector2 dir = (_target.position - transform.position).normalized;

            _rb.velocity = dir * _speed;
        }

        private void OnCollisionEnter2D(Collision2D collision)
        {
            collision.gameObject.GetComponent<EnemyHealth>().TakeDamage(_damage);
            Destroy(gameObject);
        }
    }
}
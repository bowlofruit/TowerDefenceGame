using UnityEngine;

namespace TowerDefence
{
    public class BulletController : MonoBehaviour
    {
        [SerializeField] private Rigidbody2D _rb;
        [SerializeField] private LayerMask _enemyMask;

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
            collision.gameObject.GetComponent<EnemyDeath>().TakeDamage(_damage);
            Destroy(gameObject);
        }
    }
}
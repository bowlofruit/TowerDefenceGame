using UnityEngine;
using UnityEditor;

namespace TowerDefence
{
    public class TowerShooter : MonoBehaviour
    {
        [SerializeField] private LayerMask _enemyMask;
        [SerializeField] private GameObject _bulletPrefab;

        private int _speed;
        private int _damage;
        private int _range;

        private Transform _target;
        private float _timeUntilFire;

        private void Update()
        {
            if (_target == null)
            {
                FindTarget();
                return;
            }

            if (!CheckShootArea())
            {
                _target = null;
            }
            else
            {
                _timeUntilFire += Time.deltaTime;

                if (_timeUntilFire >= 1f / _speed)
                {
                    Shoot();
                    _timeUntilFire = 0f;
                }
            }
        }

        private bool CheckShootArea()
        {
            return Vector2.Distance(_target.position, transform.position) <= _range;
        }

        private void Shoot()
        {
            GameObject bullet = Instantiate(_bulletPrefab, transform.position, Quaternion.identity);
            BulletController bulletScript = bullet.GetComponent<BulletController>();
            bulletScript.SetTarget(_target);
            bulletScript.SetSpeedAndDamage(_speed, _damage);
        }

        private void FindTarget()
        {
            RaycastHit2D[] hits = Physics2D.CircleCastAll(transform.position, _range, transform.position, 0f, _enemyMask);

            if (hits.Length > 0)
            {
                _target = hits[0].transform;
            }
        }

        private void OnDrawGizmos()
        {
            Handles.color = Color.green;
            Handles.DrawWireDisc(transform.position, transform.forward, _range);
        }

        public void InitParams(int speed, int damage, int range)
        {
            _speed = speed;
            _damage = damage;
            _range = range;
        }
    }
}
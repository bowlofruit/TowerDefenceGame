using UnityEngine;
using UnityEngine.Pool;

namespace TowerDefence
{
    public class BulletSpawner : TowerInicializator
    {
        [SerializeField] private GameObject _bulletPrefab;
        [SerializeField] private int _speed;
        [SerializeField] private int _damage;

        [SerializeField] private EnemyDetector _enemyDetector;

        private ObjectPool<GameObject> _bulletPool;
        private Transform _target;

        private void Start()
        {
            _speed = Item.Speed;
            _damage = Item.Damage;

            _bulletPool = new ObjectPool<GameObject>(() =>
            {
                return Instantiate(_bulletPrefab);
            }, bullet =>
            {
                bullet.SetActive(true);
            }, bullet =>
            {
                bullet.SetActive(false);
            }, bullet =>
            {
                Destroy(bullet);
            }, false, 10, 20);
        }

        private void Update()
        {
            if (_target == null)
            {
                _target = _enemyDetector.FindTarget();
                return;
            }

            if (_enemyDetector.IsInRange(_target))
            {
                Shoot();
            }
        }

        private void Shoot()
        {
            var bulletPrefab = _bulletPool.Get();
            bulletPrefab.transform.SetPositionAndRotation(transform.position, Quaternion.identity);

            var bulletComponent = bulletPrefab.GetComponent<Bullet>();
            bulletComponent.SetTarget(_target);
            bulletComponent.InitParams(KillBullet, _speed, _damage);
        }

        private void KillBullet(GameObject bullet)
        {
            _bulletPool.Release(bullet);
        }
    }
}
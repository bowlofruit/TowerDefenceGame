using UnityEngine;
using UnityEngine.Pool;

namespace TowerDefence
{
    public class BulletSpawner : MonoBehaviour
    {
        [SerializeField] private GameObject _bulletPrefab;
        private int _speed;
        private int _damage;

        [SerializeField] private EnemyDetector _enemyDetector;

        private ObjectPool<GameObject> _bulletPool;
        private Transform _target;
        private float _timeUntilFire;

        public int Damage { get => _damage; set => _damage = value; }
        public int Speed { get => _speed; set => _speed = value; }

        public void Init(int speed, int damage)
        {
            _speed = speed;
            _damage = damage;
        }

        private void Start()
        {
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
                _timeUntilFire += Time.deltaTime;

                if (_timeUntilFire >= 1f / _speed)
                {
                    Shoot();
                    _timeUntilFire = 0f;
                }
            }
            else
            {
                _target = null;
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
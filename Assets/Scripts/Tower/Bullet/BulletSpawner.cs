using UnityEngine;
using UnityEngine.Pool;

namespace TowerDefence
{
    public class BulletSpawner : MonoBehaviour
    {
        [SerializeField] private Bullet _bulletPrefab;
        [SerializeField] private Sprite _sprite;
        private int _speed;
        private int _damage;

        private EnemyDetector _detector;

        private ObjectPool<Bullet> _bulletPool;
        private Transform _target;
        private float _timeUntilFire;

        public int Damage { get => _damage; set => _damage = value; }
        public int Speed { get => _speed; set => _speed = value; }

        public void Init(int speed, int damage, EnemyDetector enemyDetector)
        {
            _speed = speed;
            _damage = damage;
            _detector = enemyDetector;
        }

        private void Start()
        {
            _bulletPool = new ObjectPool<Bullet>(() =>
            {
                return Instantiate(_bulletPrefab);
            }, bullet =>
            {
                bullet.gameObject.SetActive(true);
            }, bullet =>
            {
                bullet.gameObject.SetActive(false);
            }, bullet =>
            {
                Destroy(bullet.gameObject);
            }, false, 10, 20);
        }

        private void Update()
        {
            if (_target == null)
            {
                _target = _detector.FindTarget();
                return;
            }

            if (_detector.IsInRange(_target))
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
            bulletPrefab.SetTarget(_target);
            bulletPrefab.InitParams(KillBullet, _speed, _damage);
        }

        private void KillBullet(Bullet bullet)
        {
            _bulletPool.Release(bullet);
        }
    }
}
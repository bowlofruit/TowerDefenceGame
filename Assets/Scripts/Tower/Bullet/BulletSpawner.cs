using UnityEngine;
using UnityEngine.Pool;

namespace TowerDefence
{
    public class BulletSpawner : MonoBehaviour
    {
        [SerializeField] private Bullet _bulletPrefab;
        [SerializeField] private Sprite _sprite;
        private EnemyDetector _detector;

        private ObjectPool<Bullet> _bulletPool;
        private Transform _target;
        private float _timeUntilFire;

        public float Damage { get; set; }
        public float Speed { get; set; }
        public bool IsUpgrade { get; set; } = false;

        public void Init(float speed, float damage, EnemyDetector enemyDetector)
        {
            Speed = speed;
            Damage = damage;
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
            }, false, 15, 25);
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

                if (_timeUntilFire >= 1f / Speed)
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
            AudioController.Instance.PlayTowerShootSound();

            var bulletPrefab = _bulletPool.Get();
            bulletPrefab.transform.SetPositionAndRotation(transform.position, Quaternion.identity);
            bulletPrefab.SetTarget(_target);
            bulletPrefab.Init(KillBullet, Speed, Damage, IsUpgrade);
        }

        private void KillBullet(Bullet bullet)
        {
            _bulletPool.Release(bullet);
        }
    }
}
using UnityEngine;
using UnityEditor;
using UnityEngine.Pool;

namespace TowerDefence
{
    public class TowerShooter : MonoBehaviour
    {
        [SerializeField] private LayerMask _enemyMask;
        [SerializeField] private Bullet _bulletPrefab;

        [SerializeField] private int _speed;
        [SerializeField] private int _damage;
        [SerializeField] private int _range;

        private Transform _target;
        private float _timeUntilFire;

        private ObjectPool<Bullet> _bulletPool;

        public void InitParams(int speed, int damage, int range)
        {
            _speed = speed;
            _damage = damage;
            _range = range;
        }

        private void Start()
        {
            _bulletPool = new ObjectPool<Bullet>(() => { 
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
            }, false, 5, 10);
        }

        private void Update()
        {
            if (_target == null)
            {
                _target = FindTarget();
                return;
            }

            if (CheckShootArea())
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

        private bool CheckShootArea()
        {
            return _target != null && Vector2.Distance(_target.position, transform.position) <= _range;
        }

        private void Shoot()
        {
            /*GameObject bullet = ObjectPooler.Instance.GetPooledObject(_bulletPrefab);
            if (bullet != null)
            {
                bullet.transform.position = transform.position;
                bullet.transform.rotation = Quaternion.identity;

                Bullet bulletScript = bullet.GetComponent<Bullet>();
                bulletScript.SetTarget(_target);
                bulletScript.InitParams(KillBullet, _speed, _damage);
                bullet.SetActive(true);
            }*/
        }

        private Transform FindTarget()
        {
            RaycastHit2D[] hits = Physics2D.CircleCastAll(transform.position, _range, transform.position, 0f, _enemyMask);

            if (hits != null && hits.Length > 0)
            {
                return hits[0].transform;
            }
            return null;
        }

        private void KillBullet(Bullet bullet)
        {
            Destroy(bullet.gameObject);
        }

        private void OnDrawGizmos()
        {
            Handles.color = Color.green;
            Handles.DrawWireDisc(transform.position, transform.forward, _range);
        }
    }
}
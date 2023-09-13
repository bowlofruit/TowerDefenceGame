using UnityEngine;
using UnityEditor;

namespace TowerDefence
{
    public class TowerController : MonoBehaviour
    {
        [SerializeField] private TowerItem _towerItem;
        [SerializeField] private LayerMask _enemyMask;

        [SerializeField] private GameObject _bulletPrefab;
        [SerializeField] private TowerEconomic _towerEconomic;

        private Transform _target;
        private float _timeUntilFire;

        private void Awake()
        {
            _towerEconomic.SetTowerPrice(_towerItem);
        }

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

                if (_timeUntilFire >= 1f / _towerItem.Speed)
                {
                    Shoot();
                    _timeUntilFire = 0f;
                }
            }
        }

        private bool CheckShootArea()
        {
            return Vector2.Distance(_target.position, transform.position) <= _towerItem.Range;
        }

        private void Shoot()
        {
            GameObject bullet = Instantiate(_bulletPrefab, transform.position, Quaternion.identity);
            BulletController bulletScript = bullet.GetComponent<BulletController>();
            bulletScript.SetTarget(_target);
            bulletScript.SetSpeedAndDamage(_towerItem.Speed, _towerItem.Damage);
        }

        private void FindTarget()
        {
            RaycastHit2D[] hits = Physics2D.CircleCastAll(transform.position, _towerItem.Range, transform.position, 0f, _enemyMask);

            if (hits.Length > 0)
            {
                for (int i = 0; i < hits.Length; i++)
                {
                    _target = hits[i].transform;
                }
            }
        }

        private void OnDrawGizmos()
        {
            Handles.color = Color.green;
            Handles.DrawWireDisc(transform.position, transform.forward, _towerItem.Range);
        }
    }
}
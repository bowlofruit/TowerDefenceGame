using UnityEngine;

namespace TowerDefence
{
    public class UpgradeTower : MonoBehaviour
    {
        [SerializeField] private SpriteRenderer _spriteRenderer;
        [SerializeField] private Sprite[] _updateSprites;
        [SerializeField] private UpgradeType _upgradeType;

        [SerializeField] private EnemyDetector _enemyDetector;
        [SerializeField] private BulletSpawner _bulletSpawner;

        private int _updateCount = 0;

        public bool TowerUpdate()
        {
            if (_updateCount == 2) return false;

            if (_upgradeType == UpgradeType.Damage)
            {
                _bulletSpawner.Damage += _bulletSpawner.Damage + _bulletSpawner.Damage / 2;
            }
            else if (_upgradeType == UpgradeType.Range)
            {
                _enemyDetector.Range += _enemyDetector.Range + _enemyDetector.Range / 2;
            }
            else if (_upgradeType == UpgradeType.ShootSpeed)
            {
                _bulletSpawner.Speed += _bulletSpawner.Speed + _bulletSpawner.Speed / 2;
            }
            
            _updateCount++;
            _spriteRenderer.sprite = _updateSprites[_updateCount];

            return true;
        }
    }
}
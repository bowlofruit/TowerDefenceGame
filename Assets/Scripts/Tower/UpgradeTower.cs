using UnityEngine;

namespace TowerDefence
{
    public enum UpgradeType
    {
        Damage,
        Range,
        ShootSpeed
    }

    public class UpgradeTower : MonoBehaviour
    {
        [SerializeField] private SpriteRenderer _spriteRenderer;
        [SerializeField] private Sprite[] _updateSprites;
        [SerializeField] private UpgradeType _upgradeType;

        private EnemyDetector _enemyDetector;
        private BulletSpawner _bulletSpawner;

        private int _updateCount = 0;

        private const int MaxUpgrades = 2;

        public void Init(EnemyDetector enemyDetector, BulletSpawner bulletSpawner)
        {
            _enemyDetector = enemyDetector;
            _bulletSpawner = bulletSpawner;
        }

        public bool TowerUpdate()
        {
            if (_updateCount >= MaxUpgrades)
            {
                return false;
            }

            ApplyUpgrade();
            _updateCount++;
            _spriteRenderer.sprite = _updateSprites[_updateCount];

            return true;
        }

        private void ApplyUpgrade()
        {
            switch (_upgradeType)
            {
                case UpgradeType.Damage:
                    _bulletSpawner.Damage *= 1.3f;
                    break;

                case UpgradeType.Range:
                    _enemyDetector.Range *= 1.1f;
                    break;

                case UpgradeType.ShootSpeed:
                    _bulletSpawner.Speed *= 1.15f;
                    break;
            }

            if (_updateCount == 1)
            {
                _bulletSpawner.IsUpgrade = true;
            }
        }
    }
}
using UnityEngine;

namespace TowerDefence
{
    public class TowerController : MonoBehaviour
    {
        [SerializeField] private TowerItem _item;
        [SerializeField] private UpgradeTower _upgradeTower;
        [SerializeField] private BulletSpawner _bulletSpawner;
        [SerializeField] private EnemyDetector _enemyDetector;

        public int BuyPrice { get; private set; }
        public int SellPrice { get; private set; }
        public int UpgradePrice { get; private set; }
        public float Range
        {
            get
            {
                return _enemyDetector.Range;
            }
            set
            {
                _enemyDetector.Range = value;
            }
        }

        public float Speed
        {
            get
            {
                return _bulletSpawner.Speed;
            }
            set
            {
                _bulletSpawner.Speed = value;
            }
        }

        public float Damage
        {
            get
            {
                return _bulletSpawner.Damage;
            }
            set
            {
                _bulletSpawner.Damage = value;
            }
        }

        private void Awake()
        {
            _enemyDetector.Init(_item.Range);
            _bulletSpawner.Init(_item.Speed, _item.Damage, _enemyDetector);
            _upgradeTower.Init(_enemyDetector, _bulletSpawner);

            BuyPrice = _item.BuyPrice;
            SellPrice = _item.SellPrice;
            UpgradePrice = (int)(BuyPrice * 1.5f);
            UpdateUI();
        }

        public void BuyTower()
        {
            EventController.OnTowerBuy.Invoke(BuyPrice);
        }

        public void SellTower()
        {
            EventController.OnTowerSell.Invoke(SellPrice);
            Destroy(gameObject);
        }

        public void UpgradeTower()
        {
            if (CanUpgradeTower() && _upgradeTower.TowerUpdate())
            {
                EventController.OnTowerUpgrade.Invoke(UpgradePrice);

                UpgradePrice += (int)(UpgradePrice * 1.5f);
                SellPrice += (int)(SellPrice * 1.2f);
                UpdateUI();
            }
            else
            {
                Debug.Log("Can't update tower");
            }
        }

        private void UpdateUI()
        {
            EventController.OnUpdateButtonsUI.Invoke(this);
            EventController.OnUpdateInfoUI.Invoke(Range, Speed, Damage);
        }

        public bool CanBuyTower()
        {
            return CoinsController.Instance.Coins >= BuyPrice;
        }

        public bool CanUpgradeTower()
        {
            return CoinsController.Instance.Coins >= UpgradePrice;
        }
    }
}
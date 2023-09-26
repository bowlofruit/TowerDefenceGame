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
        public int Range
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

        private void Awake()
        {
            _enemyDetector.Init(_item.Range);
            _bulletSpawner.Init(_item.Speed, _item.Damage, _enemyDetector);
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
            if(CanUpgradeTower() && _upgradeTower.TowerUpdate())
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
            EventController.OnUpdateInfoUI.Invoke(_enemyDetector.Range, _bulletSpawner.Speed, _bulletSpawner.Damage);
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
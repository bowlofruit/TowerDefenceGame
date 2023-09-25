using UnityEngine;

namespace TowerDefence
{
    public class TowerEconomic : MonoBehaviour
    {
        [SerializeField] private UpgradeTower _upgradeTower;
        [SerializeField] private BulletSpawner _bulletSpawner;
        [SerializeField] private EnemyDetector _enemyDetector;

        private int _buyPrice;
        private int _sellPrice;
        private int _upgradePrice;

        public int BuyPrice { get => _buyPrice; set => _buyPrice = value; }
        public int SellPrice { get => _sellPrice; set => _sellPrice = value; }
        public int UpgradePrice { get => _upgradePrice; set => _upgradePrice = value; }

        public void Init(int buyPrice, int sellPrice)
        {
            _buyPrice = buyPrice;
            _sellPrice = sellPrice;
            _upgradePrice = (int)(_buyPrice * 1.5f);
        }

        public void BuyTower()
        {
            EventController.OnTowerBuy.Invoke(_buyPrice);
        }

        public void SellTower()
        {
            EventController.OnTowerSell.Invoke(_sellPrice);
            Destroy(gameObject);
        }

        public void UpgradeTower()
        {
            if(CanUpgradeTower() && _upgradeTower.TowerUpdate())
            {
                EventController.OnTowerUpgrade.Invoke(_upgradePrice);
                _upgradePrice += (int)(_upgradePrice * 1.5f);
                _sellPrice += (int)(_sellPrice * 1.2f);
                EventController.OnUpdateButtonsUI.Invoke(this);
                EventController.OnUpdateInfoUI.Invoke(_enemyDetector.Range, _bulletSpawner.Speed, _bulletSpawner.Damage);
            }
            else
            {
                Debug.Log("Can't update tower");
            }
        }

        public bool CanBuyTower()
        {
            return CoinsController.Instance.Coins >= _buyPrice;
        }

        public bool CanUpgradeTower()
        {
            return CoinsController.Instance.Coins >= _upgradePrice;
        }
    }
}
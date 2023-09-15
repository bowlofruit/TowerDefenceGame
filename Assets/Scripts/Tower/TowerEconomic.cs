using UnityEngine;

namespace TowerDefence
{
    public class TowerEconomic : MonoBehaviour
    {
        private int _buyPrice;
        private int _sellPrice;
        private int _upgradePrice;

        public int BuyPrice { get => _buyPrice; set => _buyPrice = value; }
        public int SellPrice { get => _sellPrice; set => _sellPrice = value; }
        public int UpgradePrice { get => _upgradePrice; set => _upgradePrice = value; }

        public void InitParams(int buyPrice, int sellPrice)
        {
            _buyPrice = buyPrice;
            _sellPrice = sellPrice;
            _upgradePrice = buyPrice + buyPrice / 2;
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
            if(CanUpgradeTower())
            {
                EventController.OnTowerUpgrade.Invoke(_upgradePrice);
                _upgradePrice += _buyPrice + _buyPrice / 2;
                EventController.OnUpdateUI.Invoke(this);
            }
            else
            {
                Debug.Log("Not enough coins to upgrade this tower.");
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
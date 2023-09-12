using UnityEngine;

namespace TowerDefence
{
    public class TowerEconomic : MonoBehaviour
    {
        private int _buyPrice;
        private int _sellPrice;
        private int _upgradePrice;

        public void SetTowerPrice(TowerItem item)
        {
            _buyPrice = item.BuyPrice;
            _sellPrice = item.SellPrice;
            _upgradePrice = item.BuyPrice + item.BuyPrice / 2;
        }

        public void BuyTower()
        {
            EventController.OnTowerBuy.Invoke(_buyPrice);
        }

        public void SellTower()
        {
            EventController.OnTowerSell.Invoke(_sellPrice);
        }

        public void UpgradeTower()
        {
            EventController.OnTowerUpgrade.Invoke(_upgradePrice);
            _upgradePrice += _buyPrice + _buyPrice / 2;
        }

        public bool CanBuyTower()
        {
            return CoinsController.Instance.Coins >= _buyPrice;
        }
    }
}
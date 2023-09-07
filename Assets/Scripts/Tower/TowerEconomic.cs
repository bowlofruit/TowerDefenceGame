using UnityEngine;

namespace TowerDefence
{
    public class TowerEconomic : MonoBehaviour
    {
        private TowerItem _item;

        public void SetTowerItem(TowerItem item)
        {
            _item = item;
        }

        public void BuyTower()
        {
            EventController.OnTowerBuy.Invoke(_item.BuyPrice);
        }

        public void SellTower()
        {
            EventController.OnTowerSell.Invoke(_item.SellPrice);
        }

        public void UpgradeTower()
        {
            EventController.OnTowerUpgrade.Invoke(_item.BuyPrice);
        }

        public bool CanBuyTower()
        {
            return CoinsController.Instance.Coins >= _item.BuyPrice;
        }
    }
}
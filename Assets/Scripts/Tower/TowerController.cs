using System.Collections;
using UnityEngine;

namespace TowerDefence
{
    public class TowerController : MonoBehaviour
    {
        [SerializeField] private TowerItem _item;
        [SerializeField] private UpgradeTower _upgradeTower;
        [SerializeField] private BulletSpawner _bulletSpawner;
        [SerializeField] private EnemyDetector _enemyDetector;

        public bool IsMaxUpgrade { get; private set; }
        public bool WasStuned { get; private set; }

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

        public TowerItem Item { get => _item; set => _item = value; }

        private void Awake()
        {
            WasStuned = true;

            _enemyDetector.Init(_item.Range);
            _bulletSpawner.Init(_item.Speed, _item.Damage, _enemyDetector);
            _upgradeTower.Init(_enemyDetector, _bulletSpawner);

            BuyPrice = _item.BuyPrice;
            SellPrice = _item.SellPrice;
            UpgradePrice = (int)(BuyPrice * 1.5f + BuyPrice);
            UpdateUI(true);
        }

        public void BuyTower()
        {
            AudioController.Instance.PlayTowerBuildSound();
            EventController.OnTowerBuy.Invoke(BuyPrice);
        }

        public void SellTower()
        {
            EventController.OnTowerSell.Invoke(SellPrice);
            Destroy(gameObject);
            ActivePlotSetter.ActivePlot = null;
        }

        public void UpgradeTower()
        {
            IsMaxUpgrade = _upgradeTower.CheckMaxUpdate();
            if (CanUpgradeTower() && !IsMaxUpgrade)
            {
                EventController.OnTowerUpgrade.Invoke(UpgradePrice);
                _upgradeTower.ApplyUpgrade();

                AudioController.Instance.PlayTowerUpgradeSound();

                UpgradePrice += (int)(UpgradePrice * 1.7f);
                SellPrice += (int)(SellPrice * 1.2f);

                UpdateUI(!IsMaxUpgrade);
            }
        }

        private void UpdateUI(bool isActiveUpdate)
        {
            EventController.OnUpdateButtonsUI.Invoke(this, isActiveUpdate);
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

        public void RemoveStunAfterDelay()
        {
            StartCoroutine(RemoveStunCoroutine());
        }

        private IEnumerator RemoveStunCoroutine()
        {
            yield return new WaitForSeconds(10);

            WasStuned = false;
        }
    }
}
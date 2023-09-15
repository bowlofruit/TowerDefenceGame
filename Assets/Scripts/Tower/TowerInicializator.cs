using UnityEngine;

namespace TowerDefence
{
    public class TowerInicializator : MonoBehaviour
    {
        [SerializeField] private TowerItem _item;

        [SerializeField] private TowerEconomic _towerEconomic;
        [SerializeField] private TowerShooter _shooter;

        public TowerItem Item { get => _item; private set => _item = value; }

        private void Awake()
        {
            _towerEconomic.InitParams(_item.BuyPrice, _item.SellPrice);
            _shooter.InitParams(_item.Speed, _item.Damage, _item.Range);
        }
    }
}
using UnityEngine;

namespace TowerDefence
{
    public enum UpgradeType
    {
        Damage,
        Range,
        ShootSpeed
    }

    [CreateAssetMenu(fileName = "Tower", menuName = "Towers/Create Tower")]
    public class TowerItem : ScriptableObject
    {
        [SerializeField] private UpgradeType _upgradeType;
        [SerializeField] private int _damage;
        [SerializeField] private int _range;
        [SerializeField] private int _speed;
        [SerializeField] private int _buyPrice;
        [SerializeField] private int _sellPrice;

        public UpgradeType UpgradeType { get => _upgradeType; set => _upgradeType = value; }
        public int Damage { get => _damage; set => _damage = value; }
        public int Range { get => _range; set => _range = value; }
        public int Speed { get => _speed; set => _speed = value; }
        public int BuyPrice { get => _buyPrice; set => _buyPrice = value; }
        public int SellPrice { get => _sellPrice; set => _sellPrice = value; }
    }
}
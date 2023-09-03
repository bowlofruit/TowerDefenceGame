using UnityEngine;

namespace TowerDefence
{
    public enum UpgradeType
    {
        Damage,
        ShootRadius,
        ShootSpeed
    }

    [CreateAssetMenu(fileName = "Tower", menuName = "Towers/Create Tower")]
    public class TowerItem : ScriptableObject
    {
        [SerializeField] private UpgradeType _upgradeType;
        [SerializeField] private int _damage;
        [SerializeField] private int _shootRadius;
        [SerializeField] private int _speed;

        public UpgradeType UpgradeType { get => _upgradeType; set => _upgradeType = value; }
        public int Damage { get => _damage; set => _damage = value; }
        public int ShootRadius { get => _shootRadius; set => _shootRadius = value; }
        public int Speed { get => _speed; set => _speed = value; }    
    }
}
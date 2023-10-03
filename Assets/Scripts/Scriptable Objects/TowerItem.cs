using UnityEngine;

namespace TowerDefence
{
    [CreateAssetMenu(fileName = "Tower", menuName = "Towers/Create Tower")]
    public class TowerItem : ScriptableObject
    {
        [SerializeField] private float _damage;
        [SerializeField] private float _range;
        [SerializeField] private float _speed;
        [SerializeField] private int _buyPrice;
        [SerializeField] private int _sellPrice;

        public float Damage { get => _damage; set => _damage = value; }
        public float Range { get => _range; set => _range = value; }
        public float Speed { get => _speed; set => _speed = value; }
        public int BuyPrice { get => _buyPrice; set => _buyPrice = value; }
        public int SellPrice { get => _sellPrice; set => _sellPrice = value; }
    }
}
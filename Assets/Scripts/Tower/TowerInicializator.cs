using UnityEngine;

namespace TowerDefence
{
    public class TowerInicializator : MonoBehaviour
    {
        [Header("Item")]
        [SerializeField] private TowerItem _item;

        [Header("ReferenceComponents")]
        [SerializeField] private BulletSpawner _spawner;
        [SerializeField] private EnemyDetector _enemyDetector;
        [SerializeField] private TowerEconomic _towerEconomic;

        public TowerItem Item { get => _item; private set => _item = value; }

        private void Awake()
        {
            _spawner.Init(Item.Speed, Item.Damage);
            _enemyDetector.Init(Item.Range);
            _towerEconomic.Init(Item.BuyPrice, Item.SellPrice);
        }
    }
}
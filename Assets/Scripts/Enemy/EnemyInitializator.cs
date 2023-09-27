using UnityEngine;

namespace TowerDefence
{
    public class EnemyInitializator : MonoBehaviour
    {
        [SerializeField] private EnemyItem _item;

        [SerializeField] private EnemyDeath _enemyDeath;
        [SerializeField] private EnemyMovement _enemyMovement;

        private void Awake()
        {
            _enemyDeath.InitParams(_item.Health, _item.Reward);
            _enemyMovement.InitParams(_item.Speed, _item.Damage);
        }
    }
}
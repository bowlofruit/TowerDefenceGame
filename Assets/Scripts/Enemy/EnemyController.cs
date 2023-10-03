using System.Collections;
using UnityEngine;

namespace TowerDefence
{
    public class EnemyController : MonoBehaviour
    {
        [SerializeField] private EnemyItem _item;

        [SerializeField] private EnemyMovement _enemyMovement;
        [SerializeField] private EnemyHealthBar _enemyHealthBar;
        private int _reward;

        public float Health { get; set; }

        private void Awake()
        {
            Health = _item.Health;
            _reward = _item.Reward;

            _enemyMovement.Init(_item.Speed, _item.Damage);
            _enemyHealthBar.Init(this);
        }

        public void TakeDamage(float damage)
        {
            Health -= damage;
            _enemyHealthBar.UpdateHealthBar();

            if (Health <= 0)
            {
                EventController.OnEnemyDestroy.Invoke();
                EventController.OnEnemyCoinsAmount.Invoke(_reward);

                AudioController.Instance.PlayEnemyDeathSound();
                Destroy(gameObject);
            }
        }

        public void TakePeriodicalDamage(float periodicDamageInterval, float periodicDamageRate, float periodicDamageAmount)
        {
            StartCoroutine(ApplyPeriodicDamage(periodicDamageInterval, periodicDamageRate, periodicDamageAmount));
        }

        private IEnumerator ApplyPeriodicDamage(float periodicDamageInterval, float periodicDamageRate, float periodicDamageAmount)
        {
            float periodicalDamageTimer = 0;

            while (periodicalDamageTimer < periodicDamageInterval)
            {
                yield return new WaitForSeconds(periodicDamageRate);
                TakeDamage(periodicDamageAmount);
                periodicalDamageTimer += periodicDamageRate;
            }
        }
    }
}
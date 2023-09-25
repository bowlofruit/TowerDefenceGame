using UnityEngine;

namespace TowerDefence
{
    public class EnemyDeath : MonoBehaviour
    {
        private int _health;
        private int _reward;

        private bool _isDestroyed = false;

        public void InitParams(int health, int reward)
        {
            _health = health;
            _reward = reward;
        }

        public void TakeDamage(float damage)
        {
            _health -= (int)damage;

            if (_health <= 0 && !_isDestroyed)
            {
                EventController.OnEnemyDestroy.Invoke();
                EventController.OnEnemyCoinsAmount.Invoke(_reward);
                _isDestroyed = true;
                Destroy(gameObject);
            }
        }
    }
}
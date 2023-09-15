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

        public void TakeDamage(int damage)
        {
            _health -= damage;

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
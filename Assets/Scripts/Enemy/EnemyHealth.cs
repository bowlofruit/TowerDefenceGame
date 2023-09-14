using UnityEngine;

namespace TowerDefence
{
    public class EnemyHealth : MonoBehaviour
    {
        [SerializeField] private int _health = 20;
        [SerializeField] private int _coins = 30;

        private bool _isDestroyed = false;

        public void TakeDamage(int damage)
        {
            _health -= damage;

            if (_health <= 0 && !_isDestroyed)
            {
                EventController.OnEnemyDestroy.Invoke();
                EventController.OnEnemyCoinsAmount.Invoke(_coins);
                _isDestroyed = true;
                Destroy(gameObject);
            }
        }
    }
}
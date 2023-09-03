using UnityEngine;

namespace TowerDefence
{
    public class EnemyHealth : MonoBehaviour
    {
        [SerializeField] private int _health = 20;

        private bool _isDestroyed = false;

        public void TakeDamage(int damage)
        {
            _health -= damage;

            if (_health <= 0 && !_isDestroyed)
            {
                EventController.OnEnemyDestroy.Invoke();
                _isDestroyed = true;
                Destroy(gameObject);
            }
        }
    }
}
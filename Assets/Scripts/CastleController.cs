using UnityEngine;

namespace TowerDefence
{
    public class CastleController : MonoBehaviour
    {
        [SerializeField] private GameObject _castlePrefab;

        [SerializeField] private int _health;

        private void Awake()
        {
            EventController.OnCastleTakeDamage.AddListener(TakeDamage);
        }

        public void InitCastle(Transform parent)
        {
            Instantiate(_castlePrefab, parent.position, Quaternion.identity);
        }

        private void TakeDamage(int damage)
        {
            _health -= damage;

            if (_health <= 0)
            {
                EventController.OnGameOver.Invoke();
            }
        }
    }
}
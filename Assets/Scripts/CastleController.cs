using TMPro;
using UnityEngine;

namespace TowerDefence
{
    public class CastleController : MonoBehaviour
    {
        [SerializeField] private GameObject _castlePrefab;
        [SerializeField] private TMP_Text _caslteHP;

        [SerializeField] private int _health;
        private int _maxHP; 

        private void Awake()
        {
            EventController.OnCastleTakeDamage.AddListener(TakeDamage);
            _maxHP = _health;
            _caslteHP.text = $"Castle:{_health}/{_maxHP}";
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
                _health = 0;
                EventController.OnGameOver.Invoke();
            }

            _caslteHP.text = $"Castle:{_health}/{_maxHP}";
        }
    }
}
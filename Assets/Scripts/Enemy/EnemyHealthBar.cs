using TowerDefence;
using UnityEngine;
using UnityEngine.UI;

public class EnemyHealthBar : MonoBehaviour
{
    [SerializeField] private Slider _healthBar;
    private EnemyController _enemyHealth;

    private float _maxHP;

    public void Init(EnemyController enemyHealth)
    {
        _enemyHealth = enemyHealth;
        _maxHP = _enemyHealth.Health;
    }

    public void UpdateHealthBar()
    {
        _healthBar.value = _enemyHealth.Health / _maxHP;
    }
}

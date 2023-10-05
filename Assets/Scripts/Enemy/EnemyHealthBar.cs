using TowerDefence;
using UnityEngine;
using UnityEngine.UI;

public class EnemyHealthBar : MonoBehaviour
{
    [SerializeField] private Slider _healthBar;
    [SerializeField] private Vector3 _offset;

    private EnemyController _enemyHealth;
    private Camera _camera;

    private float _maxHP;

    public void Init(EnemyController enemyHealth)
    {
        _camera = Camera.main;
        _enemyHealth = enemyHealth;
        _maxHP = _enemyHealth.Health;
    }

    public void UpdateHealthBar()
    {
        if(_maxHP < _enemyHealth.Health)
        {
            _enemyHealth.Health = _maxHP;
        }

        _healthBar.value = _enemyHealth.Health / _maxHP;
    }

    private void Update()
    {
        transform.SetPositionAndRotation(_enemyHealth.transform.position + _offset, _camera.transform.rotation);
    }
}

using TowerDefence;
using UnityEngine;
using UnityEngine.UI;

public class EnemyHealthBar : MonoBehaviour
{
    [SerializeField] private Slider _healthBar;
    [SerializeField] private Vector3 _offset;

    private Camera _camera;

    private Transform _transformEnemy;
    private float _maxHP;

    public void Init(EnemyController enemyHealth)
    {
        _camera = Camera.main;
        _maxHP = enemyHealth.Health;
        _transformEnemy = enemyHealth.transform;
    }

    public void UpdateHealthBar(float health)
    {
        if(_maxHP < health)
        {
            health = _maxHP;
        }

        _healthBar.value = health / _maxHP;
    }

    private void Update()
    {
        transform.SetPositionAndRotation(_transformEnemy.position + _offset, _camera.transform.rotation);
    }
}

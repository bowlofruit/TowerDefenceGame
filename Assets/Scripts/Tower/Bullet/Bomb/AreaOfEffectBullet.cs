using System;
using UnityEngine;
using UnityEngine.Pool;

namespace TowerDefence
{
    public class AreaOfEffectBullet : Bullet
    {
        [SerializeField] private float _explosionRadius;

        [SerializeField] private DamageArea _areaPrefab;
        [SerializeField] private float _areaLifeTime;
        [SerializeField][Range(0f, 1f)] private float _areaCreationChance;

        private ObjectPool<DamageArea> _areaPool;

        private void Awake()
        {
            _areaPool = new ObjectPool<DamageArea>(() => 
                { return Instantiate(_areaPrefab); },
                area => { area.gameObject.SetActive(true); },
                area => { area.gameObject.SetActive(false); },
                area => { Destroy(area.gameObject); }, false, 5, 10);
        }

        private void OnTriggerEnter2D(Collider2D collision)
        {
            if (collision.gameObject.TryGetComponent(out EnemyController enemy))
            {
                Collider2D[] colliders = Physics2D.OverlapCircleAll(transform.position, _explosionRadius);

                foreach (Collider2D collider in colliders)
                {
                    if (collider.gameObject.TryGetComponent(out EnemyController nearEnemy))
                    {
                        nearEnemy.TakeDamage(Damage);
                    }
                }

                if (_isUpgrade && UnityEngine.Random.value <= _areaCreationChance)
                {
                    CreateArea(enemy);
                }
                KillAction.Invoke(this);
            }
        }

        private void CreateArea(EnemyController enemy)
        {
            var damageArea = _areaPool.Get();
            damageArea.transform.position = enemy.transform.position;
            damageArea.StartLifeTimeArea(_areaLifeTime);
            _areaPool.Release(damageArea);
        }
    }
}
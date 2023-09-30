using System.Collections;
using UnityEngine;

namespace TowerDefence
{
    public class DamageArea : MonoBehaviour
    {
        [SerializeField] private int _damage;
        [SerializeField] private int _damageSpeed;
        private float _damageTimer;

        public void StartLifeTimeArea(float lifetime)
        {
            StartCoroutine(LifeTimeArea(lifetime));
        }

        private IEnumerator LifeTimeArea(float lifetime)
        {
            yield return new WaitForSeconds(lifetime);
            Destroy(gameObject);
        }

        private void OnTriggerStay2D(Collider2D collision)
        {
            _damageTimer += Time.deltaTime;
            if (_damageTimer >= 1f / _damageSpeed)
            {
                if (collision.TryGetComponent(out EnemyController enemy))
                {
                    enemy.TakeDamage(_damage);
                    _damageTimer = 0f;
                }
            }
        }
    }
}
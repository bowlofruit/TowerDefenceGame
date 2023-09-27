using UnityEngine;

namespace TowerDefence
{
    public class EnemySlower : MonoBehaviour
    {
        [SerializeField] private float _speedSlow;

        private EnemyDetector _enemyDetector;

        private void Awake()
        {
            _enemyDetector = GetComponent<EnemyDetector>();
        }

        private void Update()
        {
            RaycastHit2D[] hits = Physics2D.CircleCastAll(transform.position, _enemyDetector.Range, Vector2.zero);

            foreach (RaycastHit2D hit in hits)
            {
                if (hit.collider.TryGetComponent(out EnemyMovement movement))
                {
                    movement.SlowSpeed(_speedSlow);
                }
            }
        }
    }
}
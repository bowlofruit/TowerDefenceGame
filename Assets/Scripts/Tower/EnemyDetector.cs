using UnityEngine;

namespace TowerDefence
{
    public class EnemyDetector : TowerInicializator
    {
        [SerializeField] private LayerMask _enemyMask;
        [SerializeField] private int _range;

        private void Start()
        {
            _range = Item.Range;
        }

        public Transform FindTarget()
        {
            RaycastHit2D[] hits = Physics2D.CircleCastAll(transform.position, _range, Vector2.up, 0f, _enemyMask);

            if (hits != null && hits.Length > 0)
            {
                return hits[0].transform;
            }
            return null;
        }

        public bool IsInRange(Transform target)
        {
            return target != null && Vector2.Distance(target.position, transform.position) <= _range;
        }
    }
}
using UnityEngine;

namespace TowerDefence
{
    public class EnemyDetector : MonoBehaviour
    {
        [SerializeField] private LayerMask _enemyMask;

        public float Range { get; set; }

        public void Init(int range)
        {
            Range = range;
        }

        public Transform FindTarget()
        {
            RaycastHit2D[] hits = Physics2D.CircleCastAll(transform.position, Range, Vector2.up, 0f, _enemyMask);

            if (hits.Length > 0)
            {
                return hits[0].transform;
            }

            return null;
        }

        public bool IsInRange(Transform target)
        {
            return target != null && Vector2.Distance(target.position, transform.position) <= Range;
        }

        private void OnDrawGizmos()
        {
            Gizmos.color = Color.green;
            Gizmos.DrawWireSphere(transform.position, Range);
        }
    }
}
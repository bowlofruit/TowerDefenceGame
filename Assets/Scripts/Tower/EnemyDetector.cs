using UnityEditor;
using UnityEngine;

namespace TowerDefence
{
    public class EnemyDetector : MonoBehaviour
    {
        [SerializeField] private LayerMask _enemyMask;
        private int _range;

        public int Range { get => _range; set => _range = value; }

        public void Init(int range)
        {
            _range = range;
        }

        public Transform FindTarget()
        {
            RaycastHit2D[] hits = Physics2D.CircleCastAll(transform.position, _range, Vector2.up, 0f, _enemyMask);

            if (hits.Length > 0)
            {
                return hits[0].transform;
            }

            return null;
        }

        public bool IsInRange(Transform target)
        {
            return target != null && Vector2.Distance(target.position, transform.position) <= _range;
        }

        private void OnDrawGizmos()
        {
            Gizmos.color = Color.green;
            Gizmos.DrawWireSphere(transform.position, _range);
        }
    }
}
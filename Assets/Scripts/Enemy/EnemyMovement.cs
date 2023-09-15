using UnityEngine;

namespace TowerDefence
{
    public class EnemyMovement : MonoBehaviour
    {
        [SerializeField] private Rigidbody2D _rb;
        private float _moveSpeed;

        private Transform _targetPathPoint;
        private int _pathIndex;

        private void Start()
        {
            _targetPathPoint = PathController.Instance.StartPoint;
        }

        public void InitParams(float moveSpeed)
        {
            _moveSpeed = moveSpeed;
        }

        private void Update()
        {
            if (Vector2.Distance(_targetPathPoint.position, transform.position) <= 0.1f)
            {
                _pathIndex++;

                if (_pathIndex == PathController.Instance.PathPoints.Length)
                {
                    EventController.OnEnemyDestroy.Invoke();
                    Destroy(gameObject);
                    return;
                }
                else
                {
                    _targetPathPoint = PathController.Instance.PathPoints[_pathIndex];
                }
            }
        }

        private void FixedUpdate()
        {
            Vector2 dir = (_targetPathPoint.position - transform.position).normalized;
            _rb.velocity = dir * _moveSpeed;
        }
    }
}
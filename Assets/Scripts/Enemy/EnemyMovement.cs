using UnityEngine;

namespace TowerDefence
{
    public class EnemyMovement : MonoBehaviour
    {
        [SerializeField] private Rigidbody2D _rb;
        private float _moveSpeed;
        private int _castleDamage;

        private Transform _targetPathPoint;
        private int _pathIndex;

        private void Start()
        {
            _targetPathPoint = LevelCreator.Instance.WayPoints[0].transform;
        }

        public void SlowSpeed(float speed)
        {
            _moveSpeed -= speed;
        }

        public void InitParams(float moveSpeed, int castleDamage)
        {
            _moveSpeed = moveSpeed;
            _castleDamage = castleDamage;
        }

        private void Update()
        {
            if (Vector2.Distance(_targetPathPoint.position, transform.position) <= 0.1f)
            {
                _pathIndex++;

                if (_pathIndex == LevelCreator.Instance.WayPoints.Count)
                {
                    EventController.OnCastleTakeDamage.Invoke(_castleDamage);
                    EventController.OnEnemyDestroy.Invoke();
                    Destroy(gameObject);
                    return;
                }
                else
                {
                    _targetPathPoint = LevelCreator.Instance.WayPoints[_pathIndex].transform;
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
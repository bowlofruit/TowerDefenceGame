using System.Collections;
using UnityEngine;

namespace TowerDefence
{
    public class EnemyMovement : MonoBehaviour
    {
        [SerializeField] private Rigidbody2D _rb;
        private float _moveSpeed;

        private float _originalSpeed;
        private int _castleDamage;

        private Transform _targetPathPoint;
        private int _pathIndex;

        private void Start()
        {
            _originalSpeed = _moveSpeed;
            _targetPathPoint = LevelCreator.Instance.WayPoints[0].transform;
        }

        public void Init(float moveSpeed, int castleDamage)
        {
            _moveSpeed = moveSpeed;
            _castleDamage = castleDamage;
        }

        public void ChangeSpeed(float speedScalingFactor, int freezeTime)
        {
            _moveSpeed *= speedScalingFactor;
            StartCoroutine(ResetEnemySpeed(freezeTime));
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
            Vector3 dir = _targetPathPoint.position - transform.position;
            float angle = Mathf.Atan2(dir.y, dir.x) * Mathf.Rad2Deg + 90;
            transform.rotation = Quaternion.AngleAxis(angle, Vector3.forward);
        }

        private void FixedUpdate()
        {
            Vector2 dir = (_targetPathPoint.position - transform.position).normalized;
            _rb.velocity = dir * _moveSpeed;
        }

        private IEnumerator ResetEnemySpeed(int freezeTime)
        {
            yield return new WaitForSeconds(freezeTime);

            _moveSpeed = _originalSpeed;
        }
    }
}

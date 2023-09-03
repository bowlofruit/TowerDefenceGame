using UnityEngine;

public class EnemyMovement : MonoBehaviour
{
    [Range(0,100)]
    [SerializeField] private float _moveSpeed;
    [SerializeField] private Rigidbody2D _rigidbody;

    private Transform _targetPathPoint;
    private int _pathIndex;

    private void Start()
    {
        _targetPathPoint = PathData.Instantion.StartPoint;
    }

    private void Update()
    {
        if(Vector2.Distance(_targetPathPoint.position, transform.position) <= 0.1f)
        {
            _pathIndex++;

            if (_pathIndex == PathData.Instantion.PathPoints.Length)
            {
                WaveController.OnEnemyDestroy.Invoke();
                Destroy(gameObject);
                return;
            }
            else
            {
                _targetPathPoint = PathData.Instantion.PathPoints[_pathIndex];
            }
        }
    }

    private void FixedUpdate()
    {
        Vector2 dir = (_targetPathPoint.position - transform.position).normalized;
        _rigidbody.velocity = dir * _moveSpeed;
    }
}

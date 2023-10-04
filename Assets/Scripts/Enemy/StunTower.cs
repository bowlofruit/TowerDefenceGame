using System.Collections;
using TowerDefence;
using UnityEngine;

public class StunTower : MonoBehaviour
{
    [SerializeField] private float _radius;
    [SerializeField] private LayerMask _towerMask;
    [SerializeField] private float _stunTime;

    private void OnTriggerEnter2D(Collider2D collider)
    {
        if (collider.TryGetComponent<TowerController>(out var tower))
        {
            StartCoroutine(SlowDownTower(tower));
        }
    }

    private IEnumerator SlowDownTower(TowerController tower)
    {
        float originalSpeed = tower.Speed;

        tower.Speed = 0f;

        yield return new WaitForSeconds(_stunTime);

        tower.Speed = originalSpeed;
        tower.RemoveStunAfterDelay();
    }

    private void OnDrawGizmos()
    {
        Gizmos.color = Color.green;
        Gizmos.DrawWireSphere(transform.position, _radius);
    }
}

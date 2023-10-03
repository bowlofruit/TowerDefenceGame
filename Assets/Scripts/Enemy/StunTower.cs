using System.Collections;
using TowerDefence;
using UnityEngine;

public class StunTower : MonoBehaviour
{
    [SerializeField] private float _radius;
    [SerializeField] private LayerMask _towerMask;

    private void Update()
    {
        Collider2D[] towersInRadius = Physics2D.OverlapCircleAll(transform.position, _radius, _towerMask);

        foreach (var towerCollider in towersInRadius)
        {
            if (towerCollider.TryGetComponent<TowerController>(out var tower))
            {
                if (!tower.WasStuned)
                {
                    StartCoroutine(SlowDownTower(tower));
                }
            }
        }
    }

    private IEnumerator SlowDownTower(TowerController tower)
    {
        float originalSpeed = tower.Speed;

        tower.Speed = 0f;

        yield return new WaitForSeconds(3f);

        tower.Speed = originalSpeed;
        tower.RemoveStunAfterDelay();
    }
}

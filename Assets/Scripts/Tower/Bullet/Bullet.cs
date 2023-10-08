using System;
using System.Collections;
using UnityEngine;

namespace TowerDefence
{
    public class Bullet : MonoBehaviour
    {
        [SerializeField] private Rigidbody2D _rb;
        [SerializeField] protected Animator _animator;

        protected Action<Bullet> KillAction { get; set; }
        private Transform _target;
        protected bool _isUpgrade;

        private const float BULLET_SPEED = 5f;

        public float Damage { get; set; }

        public void Init(Action<Bullet> killAction, float damage, bool isUpgrade)
        {
            KillAction = killAction;
            Damage = damage;
            _isUpgrade = isUpgrade;
        }

        public void SetTarget(Transform target)
        {
            _target = target;
        }

        private void FixedUpdate()
        {
            if (!_target) return;

            Vector2 dir = (_target.position - transform.position).normalized;

            float angle = Mathf.Atan2(dir.y, dir.x) * Mathf.Rad2Deg;
            transform.rotation = Quaternion.Euler(new Vector3(0, 0, angle + -90));

            _rb.velocity = dir * BULLET_SPEED;
        }

        protected IEnumerator PlayAnimAndDestroy()
        {
            _animator.SetBool("IsActive", false);

            yield return new WaitForSeconds(0.2f);

            KillAction.Invoke(this);
        }
    }
}
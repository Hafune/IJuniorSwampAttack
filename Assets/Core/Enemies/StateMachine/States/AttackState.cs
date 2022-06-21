using UnityEngine;

public class AttackState : State
{
    [SerializeField] private int _damage;
    [SerializeField] private float _delay;
    [SerializeField] private Animator _animator;

    private float _lastAttackTime;

    private void Update()
    {
        _lastAttackTime -= Time.deltaTime;

        if (_lastAttackTime > 0)
            return;

        Attack();
        _lastAttackTime = _delay;
    }

    private void Attack()
    {
        _animator.Play("Attack");
        Target.ApplyDamage(_damage);
    }
}
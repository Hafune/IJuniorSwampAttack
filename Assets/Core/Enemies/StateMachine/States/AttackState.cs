using JetBrains.Annotations;
using UnityEngine;
using UnityEngine.Assertions;

[RequireComponent(typeof(Enemy))]
public class AttackState : State
{
    [SerializeField] private int _damage;
    [SerializeField] private float _delay;
    [SerializeField] private Animator _animator;

    [CanBeNull] private Player _target;
    private float _lastAttackTime;

    private void Awake() => Assert.IsNotNull(_animator);

    private void Start() => _target = GetComponent<Enemy>().Target;

    private void Update()
    {
        if (_target == null)
            return;

        _lastAttackTime -= Time.deltaTime;

        if (_lastAttackTime > 0)
            return;

        Attack();
        _lastAttackTime = _delay;
    }

    private void Attack()
    {
        _animator.Play("Attack");
        _target!.ApplyDamage(_damage);
    }
}
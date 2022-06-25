using UnityEngine;

[RequireComponent(typeof(Enemy))]
public class TargetDieTransition : Transition
{
    private Player _target;

    private void Start() => _target = GetComponent<Enemy>().Target;

    private void Update() => NeedTransit = _target == null;
}
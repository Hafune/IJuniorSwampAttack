using JetBrains.Annotations;
using UnityEngine;
using Random = UnityEngine.Random;

[RequireComponent(typeof(Enemy))]
public class DistanceTransition : Transition
{
    [SerializeField] private float _transitionRange;
    [SerializeField] private float _rangeSpread;

    [CanBeNull] private Player _target;

    private void Start()
    {
        _target = GetComponent<Enemy>().Target;
        _transitionRange += Random.Range(-_rangeSpread, _rangeSpread);
    }

    private void Update()
    {
        NeedTransit = !_target || Vector2.Distance(transform.position, _target!.transform.position) < _transitionRange;
    }
}
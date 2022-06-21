using UnityEngine;
using Random = UnityEngine.Random;

public class DistanceTransition : Transition
{
    [SerializeField] private float _transitionRange;
    [SerializeField] private float _rangeSpread;

    private void Start()
    {
        _transitionRange += Random.Range(-_rangeSpread, _rangeSpread);
    }

    private void Update()
    {
        NeedTransit = Vector2.Distance(transform.position, Target.transform.position) < _transitionRange;
    }
}
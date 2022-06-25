using UnityEngine;

public abstract class Transition : MonoBehaviour
{
    [SerializeField] private State _targetState;

    protected internal bool NeedTransit { get; protected set; }

    public State TargetState => _targetState;
    
    private void OnEnable() => NeedTransit = false;
}
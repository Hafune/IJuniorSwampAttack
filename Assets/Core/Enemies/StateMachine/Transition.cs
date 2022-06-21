using UnityEngine;

public abstract class Transition : MonoBehaviour
{
    [SerializeField] private State _targetState;

    protected Player Target { get; private set; }

    protected internal bool NeedTransit { get; protected set; }

    public State TargetState => _targetState;
    
    public void Init(Player target) => Target = target;

    private void OnEnable() => NeedTransit = false;
}
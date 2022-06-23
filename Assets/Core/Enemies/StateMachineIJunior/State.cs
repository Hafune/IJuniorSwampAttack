using System.Collections.Generic;
using System.Linq;
using UnityEngine;

public abstract class State : MonoBehaviour
{
    [SerializeField] private List<Transition> _transitions;

    public void Enter()
    {
        enabled = true;
        _transitions.ForEach(transition => transition.enabled = true);
    }

    public bool TryGetNext(out State nextState)
    {
        nextState = _transitions.FirstOrDefault(transition => transition.NeedTransit)?.TargetState;
        return nextState != null;
    }

    public void Exit()
    {
        _transitions.ForEach(transition => transition.enabled = false);
        enabled = false;
    }
}
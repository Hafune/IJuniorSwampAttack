using System.Collections.Generic;
using System.Linq;
using UnityEngine;

public class State : MonoBehaviour
{
    [SerializeField] private List<Transition> _transitions;

    protected Player Target { get; set; }

    public void Enter(Player target)
    {
        Target = target;
        enabled = true;

        _transitions.ForEach(transition =>
        {
            transition.enabled = true;
            transition.Init(target);
        });
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
using System;
using System.Diagnostics.CodeAnalysis;
using UnityEngine;

[RequireComponent(typeof(Enemy))]
public class EnemyStateMachine : MonoBehaviour
{
    [SerializeField] private State _startState;

    private Player _target;
    private State _currentState;

    public State Current => _currentState;

    private void Start()
    {
        _target = GetComponent<Enemy>().Target;
        ResetState(_startState);
    }

    private void Update()
    {
        if (_currentState.TryGetNext(out State nextState))
            Transit(nextState);
    }

    private void ResetState(State startState)
    {
        _currentState = startState;
        _currentState.Enter(_target);
    }

    private void Transit(State nextState)
    {
        _currentState.Exit();
        _currentState = nextState;
        _currentState.Enter(_target);
    }
}
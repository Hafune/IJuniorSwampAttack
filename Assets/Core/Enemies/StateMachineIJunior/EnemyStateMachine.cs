using UnityEngine;

[RequireComponent(typeof(Enemy))]
public class EnemyStateMachine : MonoBehaviour
{
    [SerializeField] private State _startState;

    private State _currentState;

    private void Start() => ResetState(_startState);

    private void Update()
    {
        if (_currentState.TryGetNext(out State nextState))
            Transit(nextState);
    }

    private void ResetState(State startState)
    {
        _currentState = startState;
        _currentState.Enter();
    }

    private void Transit(State nextState)
    {
        _currentState.Exit();
        _currentState = nextState;
        _currentState.Enter();
    }
}
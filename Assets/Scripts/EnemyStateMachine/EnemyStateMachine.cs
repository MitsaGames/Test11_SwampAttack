using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[RequireComponent(typeof(Enemy))]
public class EnemyStateMachine : MonoBehaviour
{
    [SerializeField] private State _firstState;

    private State _currentState;
    private Enemy _enemy;

    private void Start()
    {
        _enemy = GetComponent<Enemy>();

        ResetState(_firstState);
    }

    private void ResetState(State state)
    {
        _currentState = state;

        if (_currentState != null)
        {
            _currentState.Enter(_enemy.Target);
        }
    }

    private void Update()
    {
        if (_currentState == null)
        {
            return;
        }

        if (_currentState.TryGetNextState(out State nextState))
        {
            _currentState.Exit();

            if (nextState != null)
            {
                _currentState = nextState;
                _currentState.Enter(_enemy.Target);
            }
        }
    }
}

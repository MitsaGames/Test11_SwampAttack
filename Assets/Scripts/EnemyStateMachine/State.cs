using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public abstract class State : MonoBehaviour
{
    [SerializeField] private List<Transition> _transitions;

    private Player _target;

    public Player Target => _target;

    public void Enter(Player target)
    {
        _target = target;

        enabled = true;

        if (_transitions != null && enabled == true)
        {
            foreach (var transition in _transitions)
            {
                transition.enabled = true;
                transition.Init(_target);
            }
        }
    }

    public void Exit()
    {
        if (_transitions != null)
        {
            foreach (var transition in _transitions)
            {
                transition.enabled = false;
            }
        }

        this.enabled = false;
    }

    public bool TryGetNextState(out State targetState)
    {
        foreach (var transition in _transitions)
        {
            if (transition.NeedTransite)
            {
                targetState = transition.TargetState;
                return true;
            }
        }

        targetState = null;

        return false;
    }
}

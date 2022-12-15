using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public abstract class Transition : MonoBehaviour
{
    [SerializeField] private State _targetState;

    protected Player Target;

    public State TargetState => _targetState;
    public bool NeedTransite { get; protected set; }

    public void Init(Player target)
    {
        Target = target;
    }
}

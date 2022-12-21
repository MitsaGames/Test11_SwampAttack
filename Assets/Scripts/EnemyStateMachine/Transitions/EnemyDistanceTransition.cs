using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyDistanceTransition : Transition
{
    [SerializeField] private float _targetDistance;
    [SerializeField] private float _rangeSpread;

    private void Start()
    {
        _targetDistance += Random.Range(-_rangeSpread, _rangeSpread);
    }

    private void Update()
    {
        var currentDistance = Vector2.Distance(transform.position, Target.transform.position);

        if (_targetDistance >= currentDistance)
        {
            NeedTransite = true;
        }
    }
}

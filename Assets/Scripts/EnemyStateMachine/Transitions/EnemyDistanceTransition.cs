using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyDistanceTransition : Transition
{
    [SerializeField] private float _targetDistance;
    [SerializeField] private float _distanceRange;

    private void Update()
    {
        var currentDistance = Vector2.Distance(transform.position, Target.transform.position);
        var currentDistanceRange = Random.Range(-_distanceRange, _distanceRange);

        if (_targetDistance + currentDistanceRange >= currentDistance)
        {
            NeedTransite = true;
        }
    }
}

using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyAttackTargetState : State
{
    [SerializeField] private float _cooldown;
    [SerializeField] private int _damage;

    private float _currentCooldown;

    private void Start()
    {
        _currentCooldown = 0;
    }

    private void Update()
    {
        if (_currentCooldown <= 0)
        {
            _currentCooldown = _cooldown;
            Target.ApplyDamage(_damage);

            Debug.Log("Attack");
        }

        _currentCooldown -= Time.deltaTime;
    }
}

using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public abstract class Enemy : MonoBehaviour
{
    [SerializeField] private int _health;
    [SerializeField] private int _reward;
    [SerializeField] private Player _target;

    public void ApplyDamage(int damage)
    {
        _health -= damage;

        if (_health <= 0 )
        {
            Dying();
        }
    }

    private void Dying()
    {
        Destroy(gameObject);
    }
}

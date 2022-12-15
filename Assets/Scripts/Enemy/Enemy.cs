using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

public class Enemy : MonoBehaviour
{
    [SerializeField] private int _health;
    [SerializeField] private int _reward;
    [SerializeField] private Player _target;

    public Player Target => _target;
    public int Reward => _reward;

    public event UnityAction<Enemy> Died;

    public void Init(Player target)
    {
        _target = target;
        Died += _target.AddMoney;
    }

    public void ApplyDamage(int damage)
    {
        _health -= damage;

        if (_health <= 0)
        {
            Dying();
        }
    }

    private void Dying()
    {
        Died?.Invoke(this);
        Destroy(gameObject);
    }
}

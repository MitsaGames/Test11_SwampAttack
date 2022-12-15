using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Player : MonoBehaviour
{
    [SerializeField] private int _health;
    [SerializeField] private Weapon _currentWeapon;

    public int Money { get; private set; }

    public Weapon CurrentWeapon { get; private set; }

    private void Start()
    {
        CurrentWeapon = _currentWeapon;
    }

    public void ApplyDamage(int damage)
    {
        _health -= damage;

        if (_health <= 0)
        {
            Dying();
        }
    }

    public void Shoot()
    {
        if (_currentWeapon == null)
        {
            return;
        }

        _currentWeapon.Shoot();
    }

    public void AddMoney(Enemy enemy)
    {
        Money += enemy.Reward;
        enemy.Died -= AddMoney;
    }

    private void Dying()
    {
        Destroy(gameObject);
    }
}

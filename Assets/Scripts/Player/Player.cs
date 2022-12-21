using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

public class Player : MonoBehaviour
{
    [SerializeField] private int _health;
    [SerializeField] private Weapon _currentWeapon;

    private int _currentHealth;

    public int Money { get; private set; }

    public int CurrentHealth => _currentHealth;
    public Weapon CurrentWeapon { get; private set; }

    public event UnityAction<int, int> HealthChanged;

    private void Start()
    {
        _currentHealth = _health;
        CurrentWeapon = _currentWeapon;
    }

    public void ApplyDamage(int damage)
    {
        _currentHealth -= damage;

        HealthChanged?.Invoke(_currentHealth, _health);

        if (_currentHealth <= 0)
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

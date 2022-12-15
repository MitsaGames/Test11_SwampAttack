using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public abstract class Weapon : MonoBehaviour
{
    [SerializeField] protected float Cooldown;
    [SerializeField] private BulletStartPoint _bulletStartPoint;
    [SerializeField] private Bullet _bulletTemplate;
    [SerializeField] private float _bulletSpeed;

    private float _timeAfterShoot;

    private void Start()
    {
        _timeAfterShoot = Cooldown;
    }

    private void Update()
    {
        _timeAfterShoot += Time.deltaTime;
    }

    public void Shoot()
    {
        if (_timeAfterShoot >= Cooldown)
        {
            var bullet = Instantiate(_bulletTemplate, _bulletStartPoint.transform.position, _bulletStartPoint.transform.rotation, this.transform);
            bullet.Init(_bulletSpeed);

            _timeAfterShoot = 0f;
        }
    }
}

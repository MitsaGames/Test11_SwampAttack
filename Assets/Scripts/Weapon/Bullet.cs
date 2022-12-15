using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Bullet : MonoBehaviour
{
    [SerializeField] private int _damage;

    private float _speed;

    public void Init(float speed)
    {
        _speed = speed;
    }

    private void Update()
    {
        transform.Translate(Vector2.left * _speed * Time.deltaTime);
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.TryGetComponent(out Enemy enemy))
        {
            enemy.ApplyDamage(_damage);
        }

        //Destroy(gameObject);
    }
}

using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[RequireComponent(typeof(Player))]
public class PlayerInput : MonoBehaviour
{
    private Player _player;

    private void Start()
    {
        _player = GetComponent<Player>();
    }

    private void Update()
    {
        if (Input.GetMouseButtonDown(0)) 
        {
            _player.Shoot();
        }
    }
}

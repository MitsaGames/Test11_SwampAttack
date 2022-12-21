using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class WaveBar : Bar
{
    [SerializeField] private Spawner _spawner;

    private void Start()
    {
        SetValue(0, 1);
    }

    private void OnEnable()
    {
        _spawner.EnemySpawned += SetValue;
    }

    private void OnDisable()
    {
        _spawner.EnemySpawned -= SetValue;
    }
}

using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;
using UnityEngine.UI;

public class Spawner : MonoBehaviour
{
    [SerializeField] private List<Wave> _waves;
    [SerializeField] private Player _target;
    [SerializeField] private Transform _spawnPoint;

    private Wave _currentWave;
    private int _currentWaveIndex;
    private float _timeToNextSpawn;
    private int _spawned;

    public event UnityAction AllEnemiesSpawned;
    public event UnityAction<int, int> EnemySpawned;

    private void Start()
    {
        if (_waves != null && _waves.Count > 0)
        {
            _currentWave = _waves[_currentWaveIndex];
        }
    }

    private void Update()
    {
        if (_currentWave != null)
        {
            _timeToNextSpawn += Time.deltaTime;

            if (_spawned >= _currentWave.EnemiesCount)
            {
                AllEnemiesSpawned?.Invoke();
                _currentWave = null;
                return;
            }

            if (_timeToNextSpawn >= _currentWave.Delay)
            {
                _timeToNextSpawn = 0f;
                InstantiateEnemy(_currentWave.EnemyTemplate);
                EnemySpawned?.Invoke(++_spawned, _currentWave.EnemiesCount);
            }
        }
    }

    public void StartNextWave()
    {
        if (_waves != null && _currentWaveIndex + 1 < _waves.Count)
        {
            _currentWaveIndex++;

            _currentWave = _waves[_currentWaveIndex];
            _timeToNextSpawn = 0;
            _spawned = 0;
            EnemySpawned?.Invoke(_spawned, _currentWave.EnemiesCount);
        }
    }

    private void InstantiateEnemy(Enemy enemyTemplate)
    {
        var enemy = Instantiate(enemyTemplate, _spawnPoint.position, _spawnPoint.rotation, transform);
        enemy.Init(_target);
    }
}

[Serializable]
public class Wave
{
    public int EnemiesCount;
    public Enemy EnemyTemplate;
    public float Delay;
}

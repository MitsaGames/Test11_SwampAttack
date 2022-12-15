using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;
using UnityEngine.UI;

public class Spawner : MonoBehaviour
{
    [SerializeField] private List<Wave> _waves;
    [SerializeField] private float _timeToNextEnemy;
    [SerializeField] private Player _target;
    [SerializeField] private Transform _spawnPoint;
    [SerializeField] private Button _nextWaveButton;

    public event UnityAction NextWaveReady;

    private Wave _currentWave;
    private int _currentWaveIndex;
    private float _currentWaveTime;
    private float _currentTimeToNextEnemy;
    private float _currentTimeToNextWave;
    private int _currentWaveEnemyCount;
    private bool _nextWaveReady = false;

    private void Start()
    {
        if (_waves != null && _waves.Count > 0)
        {
            _currentWave = _waves[_currentWaveIndex];
            _currentTimeToNextWave = _currentWave.TimeToNextWave;
        }
    }

    private void Update()
    {
        _currentWaveTime += Time.deltaTime;

        if (_currentWaveTime >= _currentTimeToNextWave && _nextWaveReady == false)
        {
            _nextWaveReady = true;
            NextWaveReady?.Invoke();
        }

        if (_currentWave != null)
        {
            if (_currentWaveEnemyCount >= _currentWave.EnemiesCount)
            {
                _currentWave = null;
                return;
            }

            _currentTimeToNextEnemy += Time.deltaTime;

            if (_currentTimeToNextEnemy >= _timeToNextEnemy)
            {
                _currentTimeToNextEnemy = 0f;
                InstantiateEnemy(_currentWave.EnemyTemplate);
                _currentWaveEnemyCount++;
            }
        }
    }

    public void StartNextWave()
    {
        if (_waves != null && _currentWaveIndex + 1 < _waves.Count && _nextWaveReady)
        {
            _nextWaveReady = false;

            _currentWaveIndex++;

            _currentWave = _waves[_currentWaveIndex];
            _currentTimeToNextWave = _currentWave.TimeToNextWave;
            _currentWaveTime = 0;
            _currentTimeToNextEnemy = 0;
            _currentWaveEnemyCount = 0;
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
    public float TimeToNextWave;
}

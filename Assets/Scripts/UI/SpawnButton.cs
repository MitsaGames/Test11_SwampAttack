using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class SpawnButton : MonoBehaviour
{
    [SerializeField] private Button _nextWaveButton;
    [SerializeField] private Spawner _spawner;

    private void OnEnable()
    {
        _nextWaveButton.onClick.AddListener(_spawner.StartNextWave);
        _spawner.AllEnemiesSpawned += OnAllEnemiesSpawned;
    }

    private void OnDisable()
    {
        _nextWaveButton.onClick.RemoveListener(_spawner.StartNextWave);
        _spawner.AllEnemiesSpawned -= OnAllEnemiesSpawned;
    }

    private void OnAllEnemiesSpawned()
    {
        _nextWaveButton.gameObject.SetActive(true);
    }
}

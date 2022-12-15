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
        _spawner.NextWaveReady += OnNextWaveReady;
    }

    private void OnDisable()
    {
        _nextWaveButton.onClick.RemoveListener(_spawner.StartNextWave);
        _spawner.NextWaveReady -= OnNextWaveReady;
    }

    private void OnNextWaveReady()
    {
        _nextWaveButton.gameObject.SetActive(true);
    }
}

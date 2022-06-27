using System;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

public class Spawner : MonoBehaviour
{
    //v2021,3,4f NonReorderable - костыль, решает баг с отображением первого элемента списка в инспекторе
    [NonReorderable] [SerializeField] private List<Wave> _waves;
    [SerializeField] private Transform _spawnPoint;
    [SerializeField] private Player _player;
    [SerializeField] private UnityEvent _allEnemySpawned;
    [SerializeField] private UnityEvent<float> _onProgressChange;

    private Wave _currentWave;
    private Wave unit;
    private int _currentWaveIndex;
    private float _currentSpawnTime;
    private int _spawned;
    private int _dying;

    public void TryNextWave()
    {
        if (_currentWaveIndex + 1 >= _waves.Count)
            return;

        SetWave(++_currentWaveIndex);
        gameObject.SetActive(true);
        _spawned = 0;
        _dying = 0;
        _currentSpawnTime = 0f;
    }

    private void Start() => SetWave(_currentWaveIndex);

    private void Update()
    {
        _currentSpawnTime += Time.deltaTime;

        if (_currentSpawnTime < _currentWave.SpawnDelay)
            return;

        InstantiateEnemy();
        _spawned++;
        _currentSpawnTime = 0f;

        if (_spawned < _currentWave.EnemyCount)
            return;

        _allEnemySpawned?.Invoke();
        gameObject.SetActive(false);
    }

    private void InstantiateEnemy()
    {
        var enemy = Instantiate(_currentWave.Template, _spawnPoint.position, _spawnPoint.rotation);
        enemy.Init(_player);
        enemy.Dying += OnEnemyDying;
    }

    private void SetWave(int index) => _currentWave = _waves[index];

    private void OnEnemyDying(Enemy enemy)
    {
        enemy.Dying -= OnEnemyDying;
        _player.AddMoney(enemy.Reward);
        _onProgressChange?.Invoke((float) ++_dying / _currentWave.EnemyCount);
    }

    [Serializable]
    private class Wave
    {
        [SerializeField] public Enemy Template;
        [SerializeField] public float SpawnDelay;
        [SerializeField] public int EnemyCount;
    }
}
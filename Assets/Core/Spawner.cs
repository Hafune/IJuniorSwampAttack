using System;
using System.Collections.Generic;
using Lib;
using UnityEngine;
using UnityEngine.Events;

public class Spawner : MonoBehaviour
{
    public UnityEvent AllEnemySpawned;

    //v2021,3,4f NonReorderable - костыль, решает баг с отображением первого элемента списка в инспекторе
    [NonReorderable] [SerializeField] private List<Wave> _waves;
    [SerializeField] private Transform _spawnPoint;
    [SerializeField] private Player _player;

    private Wave _currentWave;
    private Wave unit;
    private int _currentWaveIndex;
    private float _currentSpawnTime;
    private int _spawned;

    public void TryNextWave()
    {
        if (_currentWaveIndex + 1 >= _waves.Count)
            return;

        SetWave(++_currentWaveIndex);
        gameObject.SetActive(true);
        _spawned = 0;
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

        AllEnemySpawned?.Invoke();
        gameObject.SetActive(false);
    }

    private void InstantiateEnemy()
    {
        Enemy enemy = Instantiate(_currentWave.Template, _spawnPoint.position, _spawnPoint.rotation);
        enemy.Init(_player);
        enemy.Dying += OnEnemyDying;
    }

    private void SetWave(int index) => _currentWave = _waves[index];

    private void OnEnemyDying(Enemy enemy)
    {
        enemy.Dying -= OnEnemyDying;
        _player.AddMoney(enemy.Reward);
    }

    [Serializable]
    private class Wave
    {
        [SerializeField] public Enemy Template;
        [SerializeField] public float SpawnDelay;
        [SerializeField] public int EnemyCount;
    }
}
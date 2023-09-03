using System.Collections;
using UnityEngine;
using UnityEngine.Events;

public class WaveController : MonoBehaviour
{
    [SerializeField] private WaveConfig _waveConfig;

    public static UnityEvent OnEnemyDestroy { get; set; } = new UnityEvent(); 

    private int _currentWave = 1;
    private float _timeSinceLastSpawn = 0;
    private int _enemiesAlive = 0;
    private int _enemiesLeftToSpawn;
    private bool _isSpawning = false;
    private float _timeBetweenWaves = 3f;

    private void Awake()
    {
        OnEnemyDestroy.AddListener(EnemyDestroyed);
    }

    private void Start()
    {
        StartCoroutine(StartWave());
    }

    private void Update()
    {
        if (!_isSpawning) return;

        _timeSinceLastSpawn += Time.deltaTime;

        if(_timeSinceLastSpawn >= (1f / _waveConfig.SpawnInterval) && _enemiesLeftToSpawn > 0)
        {
            SpawnEnemy();
            _enemiesLeftToSpawn--;
            _enemiesAlive++;
            _timeSinceLastSpawn = 0;
        }

        if(_enemiesAlive == 0 && _enemiesLeftToSpawn == 0)
        {
            EndWave();
        }
    }

    private void EnemyDestroyed()
    {
        _enemiesAlive--;
    }

    private void SpawnEnemy()
    {
        GameObject prefabToSpawn = _waveConfig.EnemyPrefabs[0];
        Instantiate(prefabToSpawn, PathData.Instantion.StartPoint.position, Quaternion.identity);
    }

    private int EnemiesPerWave()
    {
        return Mathf.RoundToInt(_waveConfig.NumberOfEnemies * Mathf.Pow(_currentWave, _waveConfig.DifficultScalingFactor));
    }

    private IEnumerator StartWave()
    {
        yield return new WaitForSeconds(_timeBetweenWaves);

        _isSpawning = true;
        _enemiesLeftToSpawn = EnemiesPerWave();
    }

    private void EndWave()
    {
        _isSpawning = false;
        StartCoroutine(StartWave());
    }
}
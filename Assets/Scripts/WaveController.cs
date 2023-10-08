using System.Collections;
using TMPro;
using UnityEngine;

namespace TowerDefence
{
    public class WaveController : MonoBehaviour
    {
        [SerializeField] private LevelConfig _waveConfig;
        [SerializeField] private TMP_Text _waveCounter;

        [SerializeField] private float _timeBetweenWaves = 3f;

        private int _currentWave = 0;
        private float _timeSinceLastSpawn = 0;
        private int _enemiesAlive = 0;
        private int _enemiesLeftToSpawn;
        private float _currentWaveHealthMultiplier = 1.0f;

        private bool _isBossSpawned;

        private bool _isSpawning = false;
        private bool _isGameOver;

        private void Awake()
        {
            EventController.OnEnemyDestroy.AddListener(EnemyDestroyed);
            EventController.OnGameOver.AddListener(() => { _isGameOver = true; });
        }

        private void Start()
        {
            EndWave();
        }

        private void Update()
        {
            if (!_isSpawning || _isGameOver) return;

            if (_currentWave > _waveConfig.NumberOfWaves)
            {
                EventController.OnLevelCompelete.Invoke();
                return;
            }

            _timeSinceLastSpawn += Time.deltaTime;

            if (_timeSinceLastSpawn >= 1f / _waveConfig.SpawnInterval && _enemiesLeftToSpawn > 0)
            {
                SpawnEnemy();
                _enemiesLeftToSpawn--;
                _enemiesAlive++;
                _timeSinceLastSpawn = 0;
            }

            if (_enemiesAlive <= 0 && _enemiesLeftToSpawn <= 0)
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
            GameObject prefabToSpawn;

            if (!_isBossSpawned)
            {
                prefabToSpawn = _waveConfig.EnemyPrefabs[Random.Range(0, _waveConfig.EnemyPrefabs.Length - 1)];
            }
            else
            {
                prefabToSpawn = _waveConfig.EnemyPrefabs[^1];
                _isBossSpawned = false;
            }

            GameObject enemy = Instantiate(prefabToSpawn, LevelCreator.Instance.WayPoints[0].transform.position, Quaternion.identity, transform);
            EnemyController enemyController = enemy.GetComponent<EnemyController>();

            enemyController.Health *= _currentWaveHealthMultiplier;
        }

        private IEnumerator StartWave()
        {
            yield return new WaitForSeconds(_timeBetweenWaves);

            _isSpawning = true;
            _enemiesLeftToSpawn = _waveConfig.NumberOfEnemies;

            _currentWaveHealthMultiplier += 0.25f;
        }

        private void EndWave()
        {
            _currentWave++;

            if (_currentWave <= _waveConfig.NumberOfWaves)
            {
                _isSpawning = false;
                _waveCounter.text = $"Wave {_currentWave}/{_waveConfig.NumberOfWaves}";
                StartCoroutine(StartWave());
            }

            if (_currentWave % 5 == 0)
            {
                _isBossSpawned = true;
            }
        }
    }
}
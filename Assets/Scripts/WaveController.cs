using System.Collections;
using TMPro;
using UnityEngine;

namespace TowerDefence
{
    public class WaveController : MonoBehaviour
    {
        [SerializeField] private LevelConfig _waveConfig;
        [SerializeField] private TMP_Text _waveCounter;

        private int _currentWave = 0;
        private float _timeSinceLastSpawn = 0;
        private int _enemiesAlive = 0;
        private int _enemiesLeftToSpawn;
        private bool _isSpawning = false;
        private float _timeBetweenWaves = 3f;
        private int _enemyCounter = 0;

        private void Awake()
        {
            EventController.OnEnemyDestroy.AddListener(EnemyDestroyed);
        }

        private void Start()
        {
            EndWave();
        }

        private void Update()
        {
            if (!_isSpawning || _currentWave > _waveConfig.NumberOfWaves) return;

            _timeSinceLastSpawn += Time.deltaTime;

            if (_timeSinceLastSpawn >= 1f / _waveConfig.SpawnInterval && _enemiesLeftToSpawn > 0)
            {
                SpawnEnemy();
                _enemiesLeftToSpawn--;
                _enemiesAlive++;
                _timeSinceLastSpawn = 0;
            }

            if (_enemiesAlive == 0 && _enemiesLeftToSpawn == 0)
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
            GameObject prefabToSpawn = _waveConfig.EnemyPrefabs[_enemyCounter];
            _enemyCounter = (_enemyCounter + 1)%_waveConfig.EnemyPrefabs.Length;
            Instantiate(prefabToSpawn, LevelCreator.Instance.WayPoints[0].transform.position, Quaternion.identity, transform);
            
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
            _currentWave++;
            _waveCounter.text = $"Wave {_currentWave}/{_waveConfig.NumberOfWaves}";
            StartCoroutine(StartWave());
        }
    }
}
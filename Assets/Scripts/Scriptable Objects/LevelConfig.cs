using UnityEngine;

namespace TowerDefence
{
    [CreateAssetMenu(fileName = "WaveConfig", menuName = "Wave Config/Create Wave Config")]
    public class LevelConfig : ScriptableObject
    {
        [SerializeField] private GameObject[] _enemyPrefabs;
        [SerializeField] private int _numberOfWaves;
        [SerializeField][Range(0.5f, 3f)] private float _spawnInterval;
        [SerializeField] private float _difficultScalingFactor;
        [SerializeField] private int _numberOfEnemies;
        [SerializeField] private int _startCoins;

        public GameObject[] EnemyPrefabs { get => _enemyPrefabs; set => _enemyPrefabs = value; }
        public int NumberOfWaves { get => _numberOfWaves; set => _numberOfWaves = value; }
        public float SpawnInterval { get => _spawnInterval; set => _spawnInterval = value; }
        public float DifficultScalingFactor { get => _difficultScalingFactor; set => _difficultScalingFactor = value; }
        public int NumberOfEnemies { get => _numberOfEnemies; set => _numberOfEnemies = value; }
        public int StartCoins { get => _startCoins; set => _startCoins = value; }
    }
}
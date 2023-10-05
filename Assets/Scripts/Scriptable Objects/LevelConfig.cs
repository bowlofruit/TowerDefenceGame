using UnityEngine;

namespace TowerDefence
{
    [CreateAssetMenu(fileName = "WaveConfig", menuName = "Wave Config/Create Wave Config")]
    public class LevelConfig : ScriptableObject
    {
        [SerializeField] private GameObject[] _enemyPrefabs;
        [SerializeField] private int _numberOfWaves;
        [SerializeField][Range(1f, 5f)] private float _spawnInterval;
        [SerializeField] private int _numberOfEnemies;
        [SerializeField] private int _startCoins;

        public GameObject[] EnemyPrefabs { get => _enemyPrefabs; set => _enemyPrefabs = value; }
        public int NumberOfWaves { get => _numberOfWaves; set => _numberOfWaves = value; }
        public float SpawnInterval { get => _spawnInterval; set => _spawnInterval = value; }
        public int NumberOfEnemies { get => _numberOfEnemies; set => _numberOfEnemies = value; }
        public int StartCoins { get => _startCoins; set => _startCoins = value; }
    }
}
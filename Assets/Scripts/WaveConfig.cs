using UnityEngine;

[CreateAssetMenu(fileName ="WaveConfig", menuName = "Wave Comfig/Create Wave Config")]
public class WaveConfig : ScriptableObject
{
    [SerializeField] private GameObject[] _enemyPrefabs;
    [SerializeField] private int _numberOfWaves;
    [SerializeField] [Range(1, 3)] private float _spawnInterval;
    [SerializeField] private float _difficultScalingFactor;
    [SerializeField] private int _numberOfEnemies;
 
    public GameObject[] EnemyPrefabs { get => _enemyPrefabs; set => _enemyPrefabs = value; }
    public int NumberOfWaves { get => _numberOfWaves; set => _numberOfWaves = value; }
    public float SpawnInterval { get => _spawnInterval; set => _spawnInterval = value; }
    public float DifficultScalingFactor { get => _difficultScalingFactor; set => _difficultScalingFactor = value; }
    public int NumberOfEnemies { get => _numberOfEnemies; set => _numberOfEnemies = value; }
}
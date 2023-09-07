using UnityEngine;

namespace TowerDefence
{
    public class BuildController : MonoBehaviour
    {
        [SerializeField] private GameObject[] towerPrefabs;

        private int _selectedTower = 0;

        public static BuildController Instance { get; private set; }

        private void Awake()
        {
            Instance = this;
        }

        public GameObject GetSelectedTower()
        {
            return towerPrefabs[_selectedTower];
        }
    }
}
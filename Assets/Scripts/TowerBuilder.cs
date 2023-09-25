using UnityEngine;

namespace TowerDefence
{
    public class TowerBuilder : MonoBehaviour
    {
        public static TowerBuilder Instance;

        [SerializeField] private GameObject[] _towersPrefab;
        private int _selectedTower = 0;

        private void Awake()
        {
            Instance = this;
        }

        public GameObject GetSelectedTower()
        {
            return _towersPrefab[_selectedTower];
        }

        public void SetSelectedTower(int index)
        {
            _selectedTower = index;
        }
    }
}
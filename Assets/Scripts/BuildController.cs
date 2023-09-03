using UnityEngine;

public class BuildController : MonoBehaviour
{
    public static BuildController Instantion;

    [SerializeField] private GameObject[] towerPrefabs;

    private int _selectedTower = 0;

    private void Awake()
    {
        Instantion = this;
    }

    public GameObject GetSelectedTower()
    {
        return towerPrefabs[_selectedTower];
    }
}
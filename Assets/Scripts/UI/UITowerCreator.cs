using UnityEngine;
using UnityEngine.UI;

namespace TowerDefence
{
    public class UITowerCreator : MonoBehaviour
    {
        [SerializeField] private Button _towerCretor;
        [SerializeField] GameObject _towerPrefab;

        private void Awake()
        {
            _towerCretor.onClick.AddListener(BuildTower);
        }

        private void BuildTower()
        {
            Debug.Log(ActivePlotSetter.ActivePlot.name);
            ActivePlotSetter.ActivePlot.Tower = Instantiate(_towerPrefab, ActivePlotSetter.ActivePlot.transform.position, Quaternion.identity);
        }
    }
}
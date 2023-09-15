using UnityEngine;
using UnityEngine.UI;

namespace TowerDefence
{
    public class UITowerCreator : MonoBehaviour //TODO
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
            ActivePlotSetter.ActivePlot.Tower = _towerPrefab;
            Instantiate(_towerPrefab, ActivePlotSetter.ActivePlot.transform);
        }
    }
}
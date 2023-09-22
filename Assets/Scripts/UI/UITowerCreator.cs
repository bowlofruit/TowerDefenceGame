using UnityEngine;
using UnityEngine.EventSystems;
using UnityEngine.UI;

namespace TowerDefence
{
    public class UITowerCreator : MonoBehaviour
    {
        [SerializeField] private Button _towerCretor;
        [SerializeField] private GameObject _towerPrefab;

        [SerializeField] private TowerInicializator _towerInicializator;

        [SerializeField] private GameObject _parentCreateTowerPanel;

        private void Awake()
        {
            _towerCretor.onClick.AddListener(BuildTower);
        }

        private void BuildTower()
        {
            if (CoinsController.Instance.Coins >= _towerInicializator.Item.BuyPrice)
            {
                Debug.Log("Tower was build");
                EventController.OnTowerBuy.Invoke(_towerInicializator.Item.BuyPrice);
                ActivePlotSetter.ActivePlot.Tower = Instantiate(_towerPrefab, ActivePlotSetter.ActivePlot.transform.position, Quaternion.identity);
                TowerEconomic towerEconomic = ActivePlotSetter.ActivePlot.Tower.GetComponent<TowerEconomic>();

                ActivePlotSetter.ActivePlot.UpdateUITowerInfo(_towerInicializator.Item, towerEconomic);

                ActivePlotSetter.ActivePlot = null;

                _parentCreateTowerPanel.SetActive(false);
            }
        }
    }
}
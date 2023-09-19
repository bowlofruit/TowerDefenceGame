using UnityEngine;
using UnityEngine.UI;

namespace TowerDefence
{
    public class UITowerCreator : MonoBehaviour
    {
        [SerializeField] private Button _towerCretor;
        [SerializeField] private GameObject _towerPrefab;
        [SerializeField] private TowerInicializator _towerInicializator;

        private void Awake()
        {
            _towerCretor.onClick.AddListener(BuildTower);
        }

        private void BuildTower()
        {
            if (CoinsController.Instance.Coins >= _towerInicializator.Item.BuyPrice)
            {
                EventController.OnTowerBuy.Invoke(_towerInicializator.Item.BuyPrice);
                ActivePlotSetter.ActivePlot.Tower = Instantiate(_towerPrefab, ActivePlotSetter.ActivePlot.transform.position, Quaternion.identity);
            }
        }
    }
}
using UnityEngine;

namespace TowerDefence
{
    public class PlotTowerSettings : MonoBehaviour
    {
        private GameObject _tower;
        private bool _isGround;

        private TowerEconomic _towerEconomic;
        private TowerInicializator _towerInicializator;

        public GameObject Tower { get => _tower; set => _tower = value; }
        public bool IsGround { get => _isGround; set => _isGround = value; }

        private void OnMouseDown()
        {
            if (IsGround) return;

            if (_tower == null)
            {
                GameObject towerToBuild = TowerBuilder.Instance.GetSelectedTower();
                if (towerToBuild.TryGetComponent(out TowerInicializator tower))
                {
                    if (tower.Item.BuyPrice <= CoinsController.Instance.Coins)
                    {
                        _tower = Instantiate(towerToBuild, transform.position, Quaternion.identity);

                        _towerEconomic = _tower.GetComponent<TowerEconomic>();
                        _towerEconomic.BuyTower();

                        _towerInicializator = tower;

                        EventController.OnUpdateUI.Invoke(_towerEconomic, _towerInicializator.Item);
                    }
                    else
                    {
                        return;
                    }
                }
            }
            else
            {
                EventController.OnUpdateUI.Invoke(_towerEconomic, _towerInicializator.Item);
            }

            ActivePlotSetter.ActivePlot = this;
            EventController.OnPlotSelected.Invoke(this);
        }
    }
}
using UnityEngine;

namespace TowerDefence
{
    public class PlotTowerSettings : MonoBehaviour
    {
        private TowerController _tower;
        private bool _isGround;

        public TowerController Tower { get => _tower; set => _tower = value; }
        public bool IsGround { get => _isGround; set => _isGround = value; }

        private void OnMouseDown()
        {
            if (IsGround) return;

            if (_tower == null)
            {
                GameObject towerToBuild = TowerBuilder.Instance.GetSelectedTower();
                if (towerToBuild.TryGetComponent(out TowerController tower))
                {
                    if (tower.CanBuyTower())
                    {
                        _tower = Instantiate(tower, transform.position, Quaternion.identity);
                        _tower.BuyTower();
                    }
                    else
                    {
                        return;
                    }
                }
            }
            else
            {
                EventController.OnUpdateButtonsUI.Invoke(Tower);
                EventController.OnUpdateInfoUI.Invoke(Tower.Range, Tower.Speed, Tower.Damage);
            }

            ActivePlotSetter.ActivePlot = this;
            EventController.OnPlotSelected.Invoke(this);
        }
    }
}
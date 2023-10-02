using UnityEngine;

namespace TowerDefence
{
    public class PlotTowerSettings : MonoBehaviour
    {
        private TowerController _tower;

        public TowerController Tower { get => _tower; set => _tower = value; }
        public bool IsGround { get; set; }

        public static bool IsFreezeTime { get; set; } 

        private void OnMouseDown()
        {
            if (IsGround || IsFreezeTime) return;

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
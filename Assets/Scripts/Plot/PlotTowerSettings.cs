using UnityEngine;

namespace TowerDefence
{
    public class PlotTowerSettings : MonoBehaviour
    {
        private TowerController _tower;

        public TowerController Tower { get => _tower; set => _tower = value; }
        public bool IsGround { get; set; }
        public bool IsDecorate { get; set; }

        public static bool IsFreezeTime { get; set; } 

        private void OnMouseDown()
        {
            if (IsGround || IsFreezeTime || IsDecorate) return;

            if (_tower == null)
            {
                GameObject towerToBuild = TowerBuilder.Instance.GetSelectedTower();
                if (towerToBuild.TryGetComponent(out TowerController tower))
                {
                    if (CoinsController.Instance.Coins >= tower.Item.BuyPrice)
                    {
                        _tower = Instantiate(tower, transform.position, Quaternion.identity);
                        _tower.BuyTower();

                        UpdateUIAndDrawCircle();
                    }
                    else
                    {
                        return;
                    }
                }
            }
            else
            {
                UpdateUIAndDrawCircle();
            }

            ActivePlotSetter.ActivePlot = this;
            EventController.OnPlotSelected.Invoke(this);
        }

        private void UpdateUIAndDrawCircle()
        {
            EventController.OnUpdateButtonsUI.Invoke(Tower, !_tower.IsMaxUpgrade);
            EventController.OnUpdateInfoUI.Invoke(Tower.Range, Tower.Speed, Tower.Damage);
            CircleRenderer.Instance.DrawCircle(Tower);
        }
    }
}
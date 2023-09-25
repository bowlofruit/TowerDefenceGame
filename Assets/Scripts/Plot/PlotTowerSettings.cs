using UnityEngine;

namespace TowerDefence
{
    public class PlotTowerSettings : MonoBehaviour
    {
        private GameObject _tower;
        private bool _isGround;

        private TowerEconomic _towerEconomic;
        private BulletSpawner _bulletSpawner;
        private EnemyDetector _enemyDetector;

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

                        EventController.OnUpdateButtonsUI.Invoke(_towerEconomic);

                        _bulletSpawner = _tower.GetComponent<BulletSpawner>();
                        _enemyDetector = _tower.GetComponent<EnemyDetector>();
                        EventController.OnUpdateInfoUI.Invoke(_enemyDetector.Range, _bulletSpawner.Speed, _bulletSpawner.Damage);
                    }
                    else
                    {
                        return;
                    }
                }
            }
            else
            {
                EventController.OnUpdateButtonsUI.Invoke(_towerEconomic);
            }

            ActivePlotSetter.ActivePlot = this;
            EventController.OnPlotSelected.Invoke(this);
        }
    }
}
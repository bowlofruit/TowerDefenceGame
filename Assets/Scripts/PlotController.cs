using UnityEngine;

namespace TowerDefence
{
    public class PlotController : MonoBehaviour
    {
        [SerializeField] private SpriteRenderer _sr;
        [SerializeField] private Color _hoverColor;
        [SerializeField] private TowerInfoUpdater _updaterUI;

        private GameObject _tower;
        private Color _startColor;
        private TowerEconomic _towerEconomic;
        private TowerItem _towerItem;

        private bool _isActiveUI = false;

        private void Start()
        {
            _startColor = _sr.color;
            _updaterUI = Camera.main.GetComponent<TowerInfoUpdater>();
        }

        private void OnMouseEnter()
        {
            _sr.color = _hoverColor;
        }

        private void OnMouseExit()
        {
            _sr.color = _startColor;
        }

        private void OnMouseDown()
        {
            if (_tower == null)
            {
                BuildTower();
            }
            else
            {
                ToggleUI();
            }
        }

        private void BuildTower()
        {
            GameObject towerToBuild = BuildController.Instance.GetSelectedTower();
            _tower = Instantiate(towerToBuild, transform.position, Quaternion.identity);

            _towerEconomic = _tower.GetComponent<TowerEconomic>();
            _towerItem = _tower.GetComponent<TowerController>().TowerItem;

            if (_towerEconomic.CanBuyTower())
            {
                _towerEconomic.BuyTower();
                _towerEconomic.SetTowerPrice(_towerItem);
            }
            else
            {
                Destroy(_tower);

                _towerEconomic = null;
                _tower = null;
                _towerItem = null;

                Debug.Log("Not enough coins to build this tower.");
            }
        }

        private void ToggleUI()
        {
            if (_isActiveUI)
            {
                _updaterUI.RemoveButtonsListeners();
                _updaterUI.HideInfo();
            }
            else
            {
                _updaterUI.SetButtonsListeners(_towerEconomic);
                _updaterUI.ShowInfo(_towerItem, _towerEconomic);
            }
            _isActiveUI = !_isActiveUI;
        }
    }
}
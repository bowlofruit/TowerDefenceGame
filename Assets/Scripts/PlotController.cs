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

        private void Start()
        {
            _startColor = _sr.color;
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
            if(_tower == null)
            {
                BuildTower();
            }
            else
            {
                _updaterUI.ShowInfoAboveObject(transform.position);
            }
        }

        private void BuildTower()
        {
            GameObject towerToBuild = BuildController.Instance.GetSelectedTower();
            _tower = Instantiate(towerToBuild, transform.position, Quaternion.identity);
            _towerEconomic = _tower.GetComponent<TowerEconomic>();

            if (_towerEconomic.CanBuyTower())
            {
                _towerEconomic.BuyTower();
            }
            else
            {
                Destroy(_tower);
                _towerEconomic = null;
                _tower = null;
                Debug.Log("Not enough coins to build this tower.");
            }
        }
    }
}
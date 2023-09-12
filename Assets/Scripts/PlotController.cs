using UnityEngine;

namespace TowerDefence
{
    public class PlotController : MonoBehaviour
    {
        [SerializeField] private SpriteRenderer _sr;
        [SerializeField] private Color _hoverColor;

        private GameObject _tower;
        private TowerEconomic _towerEconomic;
        private Color _startColor;

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
            BuildTower();
            
            if( _tower != null)
            {
                
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
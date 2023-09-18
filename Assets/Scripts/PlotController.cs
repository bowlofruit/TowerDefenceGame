using UnityEngine;

namespace TowerDefence
{
    public class PlotController : MonoBehaviour
    {
        [SerializeField] private SpriteRenderer _sr;
        [SerializeField] private Color _hoverColor;
        [SerializeField] private UITowerInfoUpdater _UIUpdater;
        [SerializeField] private GameObject _UITowerCreator;

        private Color _startColor;
        private GameObject _tower;

        public GameObject Tower { get => _tower; set => _tower = value; }

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
                ToggleUI(_UITowerCreator, _UIUpdater.gameObject);
                ActivePlotSetter.ActivePlot = this;
            }
            else
            {
                TowerItem towerItem = _tower.GetComponent<TowerInicializator>().Item;
                TowerEconomic towerEconomic = _tower.GetComponent<TowerEconomic>();
                ToggleUI(_UIUpdater.gameObject, _UITowerCreator);
                _UIUpdater.SetTowerSetting(towerItem);
                _UIUpdater.SetParamsText(towerEconomic);
                _UIUpdater.SetButtonsListeners(towerEconomic);
            }
        }

        private void ToggleUI(GameObject panel, GameObject otherPanel)
        {
            otherPanel.SetActive(false);
            if (panel.activeSelf)
            {
                panel.SetActive(false);
            }
            else
            {
                panel.GetComponent<UIMovement>().ReplaceWindow();
                panel.SetActive(true);
            }
        }
    }
}
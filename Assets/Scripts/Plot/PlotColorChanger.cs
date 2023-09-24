using UnityEngine;

namespace TowerDefence
{
    public class PlotColorChanger : MonoBehaviour
    {
        [SerializeField] private SpriteRenderer _sr;
        [SerializeField] private Color _hoverColor;
        [SerializeField] private Color _selectedColor;

        private Color _normalColor;
        private PlotTowerSettings _plotTowerSettings;

        private void Start()
        {
            _normalColor = _sr.color;
            _plotTowerSettings = GetComponent<PlotTowerSettings>();
            EventController.OnPlotSelected.AddListener(CheckActivityPlot);
        }

        private void OnMouseEnter()
        {
            if(ActivePlotSetter.ActivePlot != _plotTowerSettings)
            {
                ChangeColor(_hoverColor);
            }
        }

        private void OnMouseExit()
        {
            if (ActivePlotSetter.ActivePlot != _plotTowerSettings)
            {
                ChangeColor(_normalColor);
            }
        }

        private void ChangeColor(Color newColor)
        {
            _sr.color = newColor;
        }

        private void CheckActivityPlot(PlotTowerSettings plotTower)
        {
            if (ActivePlotSetter.ActivePlot == _plotTowerSettings)
            {
                ChangeColor(_selectedColor);
            }
            else
            {
                ChangeColor(_normalColor);
            }
        }
    }
}
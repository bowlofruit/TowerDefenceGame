using UnityEngine;

namespace TowerDefence
{
    public class PlotColorChanger : MonoBehaviour
    {
        [SerializeField] private SpriteRenderer _sr;
        [SerializeField] private Color _hoverColor;

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
    }
}
using TMPro;
using UnityEngine;

namespace TowerDefence
{
    public class TowerInfoUpdater : MonoBehaviour
    {
        [SerializeField] private Canvas _infoCanvas;

        [Header("Buttons settings")]
        [SerializeField] private TMP_Text _updatePrice;
        [SerializeField] private TMP_Text _sellPrice;

        [Header("Tower params")]
        [SerializeField] private TMP_Text _rangeText;
        [SerializeField] private TMP_Text _speedText;
        [SerializeField] private TMP_Text _damageText;

        [SerializeField] private Camera _mainCamera;

        private int _range;
        private int _speed;
        private int _damage;

        public void SetTowerSetting(TowerItem item)
        {
            _range = item.Range;
            _speed = item.Speed;
            _damage = item.Damage;

            SetParamsText();
        }

        private void SetParamsText()
        {
            _rangeText.text = _range.ToString();
            _speedText.text = _speed.ToString();
            _damageText.text = _damage.ToString();
        }

        public void ShowInfoAboveObject(Vector3 worldPosition)
        {
            _infoCanvas.gameObject.SetActive(true);

            float cameraHeight = _mainCamera.orthographicSize * 2;

            Vector2 screenPosition = Camera.main.WorldToScreenPoint(worldPosition);

            if (screenPosition.y > cameraHeight / 2f)
            {
                _infoCanvas.GetComponent<RectTransform>().pivot = new Vector2(0.5f, 1f);
            }
            else
            {
                _infoCanvas.GetComponent<RectTransform>().pivot = new Vector2(0.5f, 0f);
            }

            _infoCanvas.GetComponent<RectTransform>().position = screenPosition;
        }

        public void HideInfo()
        {
            _infoCanvas.gameObject.SetActive(false);
        }
    }
}
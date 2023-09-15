using TMPro;
using UnityEngine;
using UnityEngine.UI;

namespace TowerDefence
{
    public class UITowerInfoUpdater : MonoBehaviour
    {
        [SerializeField] private GameObject _infoPanel;

        [Header("Buttons settings")]
        [SerializeField] private Button _updateButton;
        [SerializeField] private Button _sellButton;

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

        private void Awake()
        {
            EventController.OnUpdateUI.AddListener(SetParamsText);
        }

        public void SetTowerSetting(TowerItem item, TowerEconomic towerEconomic)
        {
            _range = item.Range;
            _speed = item.Speed;
            _damage = item.Damage;

            SetParamsText(towerEconomic);
        }

        public void SetButtonsListeners(TowerEconomic towerEconomic)
        {
            _updateButton.onClick.AddListener(towerEconomic.UpgradeTower);
            _sellButton.onClick.AddListener(towerEconomic.SellTower);
            _sellButton.onClick.AddListener(HideInfo);
        }

        public void RemoveButtonsListeners()
        {
            _updateButton.onClick.RemoveAllListeners();
            _sellButton.onClick.RemoveAllListeners();
        }

        private void SetParamsText(TowerEconomic towerEconomic)
        {
            _updatePrice.text = towerEconomic.UpgradePrice.ToString();
            _sellPrice.text = towerEconomic.SellPrice.ToString();

            _rangeText.text = _range.ToString();
            _speedText.text = _speed.ToString();
            _damageText.text = _damage.ToString();
        }

        public void RefreshInfo(TowerItem item, TowerEconomic towerEconomic)
        {
            SetTowerSetting(item, towerEconomic);

            Vector3 mousePosition = _mainCamera.ScreenToWorldPoint(Input.mousePosition);

            _infoPanel.transform.position = new Vector3(mousePosition.x, mousePosition.y, 0f);

            if (mousePosition.y > 0)
            {
                _infoPanel.transform.position += new Vector3(0f, -2.5f, 0f);
            }
            else
            {
                _infoPanel.transform.position += new Vector3(0f, 2.5f, 0f);
            }
        }

        private void HideInfo()
        {
            _infoPanel.SetActive(false);
        }
    }
}
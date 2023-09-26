using TMPro;
using UnityEngine;
using UnityEngine.UI;

namespace TowerDefence
{
    public class UITowerInfoUpdater : MonoBehaviour
    {
        [Header("Buttons settings")]
        [SerializeField] private Button _updateButton;
        [SerializeField] private Button _sellButton;

        [SerializeField] private TMP_Text _updatePrice;
        [SerializeField] private TMP_Text _sellPrice;

        [Header("Tower params")]
        [SerializeField] private TMP_Text _rangeText;
        [SerializeField] private TMP_Text _speedText;
        [SerializeField] private TMP_Text _damageText;

        private void Awake()
        {
            EventController.OnUpdateButtonsUI.AddListener(SetParamsText);
            EventController.OnUpdateInfoUI.AddListener(SetTowerInfoText);
        }

        private void SetParamsText(TowerController towerEconomic)
        {
            RemoveButtonsListeners();
            SetButtonsListeners(towerEconomic);

            _updatePrice.text = towerEconomic.UpgradePrice.ToString();
            _sellPrice.text = towerEconomic.SellPrice.ToString();
        }

        private void SetTowerInfoText(int range, int speed, int damage)
        {
            _rangeText.text = range.ToString();
            _speedText.text = speed.ToString();
            _damageText.text = damage.ToString();
        }

        private void SetButtonsListeners(TowerController towerEconomic)
        {
            _updateButton.onClick.AddListener(towerEconomic.UpgradeTower);
            _sellButton.onClick.AddListener(towerEconomic.SellTower);
        }

        private void RemoveButtonsListeners()
        {
            _updateButton.onClick.RemoveAllListeners();
            _sellButton.onClick.RemoveAllListeners();
        }
    }
}
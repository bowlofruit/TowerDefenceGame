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

        private void SetParamsText(TowerController towerEconomic, bool isUpdateApdate)
        {
            RemoveButtonsListeners();
            SetButtonsListeners(towerEconomic, isUpdateApdate);

            _updatePrice.text = towerEconomic.UpgradePrice.ToString();
            _sellPrice.text = towerEconomic.SellPrice.ToString();
        }

        private void SetTowerInfoText(float range, float speed, float damage)
        {
            _rangeText.text = ((int)(range * 10)).ToString();
            _speedText.text = ((int)(speed * 10)).ToString();
            _damageText.text = ((int)(damage * 10)).ToString();
        }

        private void SetButtonsListeners(TowerController towerEconomic, bool isUpdateActive)
        {
            _updateButton.gameObject.SetActive(isUpdateActive);

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
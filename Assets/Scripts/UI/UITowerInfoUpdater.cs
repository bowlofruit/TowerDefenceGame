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

        private int _range;
        private int _speed;
        private int _damage;

        public static UITowerInfoUpdater Instance;

        private void Awake()
        {
            Instance = this;
            EventController.OnUpdateUI.AddListener(SetParamsText);
        }

        private void InitTowerSetting(TowerItem item)
        {
            _range = item.Range;
            _speed = item.Speed;
            _damage = item.Damage;
        }

        private void SetButtonsListeners(TowerEconomic towerEconomic)
        {
            _updateButton.onClick.AddListener(towerEconomic.UpgradeTower);

            _sellButton.onClick.AddListener(towerEconomic.SellTower);
            _sellButton.onClick.AddListener(() => ActivePlotSetter.ActivePlot = null);
        }

        private void RemoveButtonsListeners()
        {
            _updateButton.onClick.RemoveAllListeners();
            _sellButton.onClick.RemoveAllListeners();
        }

        public void SetParamsText(TowerEconomic towerEconomic, TowerItem item)
        {
            RemoveButtonsListeners();

            _updatePrice.text = towerEconomic.UpgradePrice.ToString();
            _sellPrice.text = towerEconomic.SellPrice.ToString();

            InitTowerSetting(item);
            SetButtonsListeners(towerEconomic);

            _rangeText.text = _range.ToString();
            _speedText.text = _speed.ToString();
            _damageText.text = _damage.ToString();
        }
    }
}
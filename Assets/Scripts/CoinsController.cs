using TMPro;
using UnityEngine;

namespace TowerDefence
{
    public class CoinsController : MonoBehaviour
    {
        [SerializeField] private int _coins;
        [SerializeField] private LevelConfig _levelConfig;
        [SerializeField] private TMP_Text _coinsText;

        public int Coins { get => _coins; private set => _coins = value; }

        public static CoinsController Instance { get; private set; }

        private void Awake()
        {
            Instance = this;
            _coins = _levelConfig.StartCoins;

            UpdateViewCoinsUI();

            EventController.OnTowerBuy.AddListener(RemoveCoins);
            EventController.OnTowerSell.AddListener(AddCoins);
            EventController.OnTowerUpgrade.AddListener(RemoveCoins);

            EventController.OnEnemyCoinsAmount.AddListener(AddCoins);
        }

        private void AddCoins(int coins)
        {
            _coins += coins;
            UpdateViewCoinsUI();
        }

        private void RemoveCoins(int coins)
        {
            _coins -= coins;
            UpdateViewCoinsUI();
        }

        private void UpdateViewCoinsUI() => _coinsText.text = _coins.ToString();
    }
}
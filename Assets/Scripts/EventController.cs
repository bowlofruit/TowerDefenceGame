using TowerDefence;
using UnityEngine;
using UnityEngine.Events;

public class EventController : MonoBehaviour
{
    public static UnityEvent OnEnemyDestroy { get; set; } = new UnityEvent();
    public static UnityEvent<int> OnEnemyCoinsAmount { get; set; } = new UnityEvent<int>();

    public static UnityEvent<int> OnCastleTakeDamage { get; set; } = new UnityEvent<int>();

    public static UnityEvent OnGameOver { get; set; } = new UnityEvent();
    public static UnityEvent OnLevelCompelete { get; set; } = new UnityEvent();

    public static UnityEvent<int> OnTowerBuy { get; set; } = new UnityEvent<int>();
    public static UnityEvent<int> OnTowerSell { get; set; } = new UnityEvent<int>();
    public static UnityEvent<int> OnTowerUpgrade { get; set; } = new UnityEvent<int>();

    public static UnityEvent<float, float, float> OnUpdateInfoUI { get; set; } = new UnityEvent<float, float, float>();
    public static UnityEvent<TowerController> OnUpdateButtonsUI { get; set; } = new UnityEvent<TowerController>();

    public static UnityEvent<PlotTowerSettings> OnPlotSelected { get; set; } = new UnityEvent<PlotTowerSettings>();
}

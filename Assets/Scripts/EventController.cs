using TowerDefence;
using UnityEngine;
using UnityEngine.Events;

public class EventController : MonoBehaviour
{
    public static UnityEvent OnEnemyDestroy { get; set; } = new UnityEvent();
    public static UnityEvent<int> OnEnemyCoinsAmount { get; set; } = new UnityEvent<int>();

    public static UnityEvent<int> OnTowerBuy { get; set; } = new UnityEvent<int>();
    public static UnityEvent<int> OnTowerSell { get; set; } = new UnityEvent<int>();
    public static UnityEvent<int> OnTowerUpgrade { get; set; } = new UnityEvent<int>();

    public static UnityEvent<TowerEconomic, TowerItem> OnUpdateUI { get; set; } = new UnityEvent<TowerEconomic, TowerItem>();

    public static UnityEvent<PlotTowerSettings> OnPlotSelected { get; set; } = new UnityEvent<PlotTowerSettings>();
}

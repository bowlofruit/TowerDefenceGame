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

    public static UnityEvent<int, int, int> OnUpdateInfoUI { get; set; } = new UnityEvent<int, int, int>();
    public static UnityEvent<TowerController> OnUpdateButtonsUI { get; set; } = new UnityEvent<TowerController>();

    public static UnityEvent<PlotTowerSettings> OnPlotSelected { get; set; } = new UnityEvent<PlotTowerSettings>();
}

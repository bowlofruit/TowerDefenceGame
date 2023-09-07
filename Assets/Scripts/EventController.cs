using UnityEngine;
using UnityEngine.Events;

public class EventController : MonoBehaviour
{
    public static UnityEvent OnEnemyDestroy { get; set; } = new UnityEvent();

    public static UnityEvent<int> OnTowerBuy { get; set; } = new UnityEvent<int>();
    public static UnityEvent<int> OnTowerSell { get; set; } = new UnityEvent<int>();
    public static UnityEvent<int> OnTowerUpgrade { get; set; } = new UnityEvent<int>();
}

using UnityEngine;
using UnityEngine.Events;

public class EventController : MonoBehaviour
{
    public static UnityEvent OnEnemyDestroy { get; set; } = new UnityEvent();
}

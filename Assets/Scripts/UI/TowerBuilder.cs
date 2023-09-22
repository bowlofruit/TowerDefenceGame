using UnityEngine;

public class TowerBuilder : MonoBehaviour
{
    public static TowerBuilder Instance;

    private void Awake()
    {
        Instance = this;
    }
}

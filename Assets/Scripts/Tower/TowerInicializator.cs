using UnityEngine;

namespace TowerDefence
{
    public class TowerInicializator : MonoBehaviour
    {
        [SerializeField] private TowerItem _item;

        public TowerItem Item { get => _item; private set => _item = value; }
    }
}
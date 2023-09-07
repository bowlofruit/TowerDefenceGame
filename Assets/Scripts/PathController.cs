using UnityEngine;

namespace TowerDefence
{
    public class PathController : MonoBehaviour
    {
        [SerializeField] private Transform _startPoint;
        [SerializeField] private Transform[] _path;

        public Transform StartPoint { get => _startPoint; }
        public Transform[] PathPoints { get => _path; }

        public static PathController Instance { get; private set; }

        private void Awake()
        {
            Instance = this;
        }
    }
}
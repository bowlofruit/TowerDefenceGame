using UnityEngine;

namespace TowerDefence
{
    public class PathData : MonoBehaviour
    {
        [SerializeField] private Transform _startPoint;
        [SerializeField] private Transform[] _path;

        public Transform StartPoint { get => _startPoint; }
        public Transform[] PathPoints { get => _path; }

        public static PathData Instantion;

        private void Awake()
        {
            Instantion = this;
        }
    }
}
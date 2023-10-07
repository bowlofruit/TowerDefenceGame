using UnityEngine;

namespace TowerDefence
{
    [RequireComponent(typeof(LineRenderer))]
    public class CircleRenderer : MonoBehaviour
    {
        private static CircleRenderer instance;

        [SerializeField] private LineRenderer _lineRenderer;
        [SerializeField] private int _vertexCount = 36;

        public static CircleRenderer Instance { get => instance; set => instance = value; }

        private void Awake()
        {
            Instance = this;
        }

        public void DrawCircle(TowerController tower)
        {
            transform.position = tower.transform.position;
            _lineRenderer.positionCount = _vertexCount + 1;

            float deltaTheta = 2f * Mathf.PI / _vertexCount;
            float theta = 0f;

            for (int i = 0; i < _vertexCount + 1; i++)
            {
                float x = tower.Range * Mathf.Cos(theta);
                float y = tower.Range * Mathf.Sin(theta);
                Vector3 pos = new(x, y, 0f);
                _lineRenderer.SetPosition(i, pos);
                theta += deltaTheta;
            }
        }
    }
}
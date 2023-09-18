using UnityEngine;

public class CloseWindowOnClickOutside : MonoBehaviour
{
    private Camera _mainCamera;
    bool _isWindowActive = true;

    private void Start()
    {
        _mainCamera = Camera.main;
    }

    private void Update()
    {
        if (_isWindowActive && Input.GetMouseButtonDown(0))
        {
            RaycastHit hit;
            Ray ray = _mainCamera.ScreenPointToRay(Input.mousePosition);

            if (Physics.Raycast(ray, out hit))
            {
                Debug.Log(hit.collider.gameObject);
                if (hit.collider.gameObject != gameObject || hit.collider.gameObject == null)
                {
                    CloseWindow();
                }
            }
        }
    }

    private void CloseWindow()
    {
        gameObject.SetActive(false);
    }
}

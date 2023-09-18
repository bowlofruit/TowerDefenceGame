using UnityEngine;

public class UIMovement : MonoBehaviour
{
    [SerializeField] private Camera _mainCamera;

    public void ReplaceWindow()
    {
        Vector3 mousePosition = _mainCamera.ScreenToWorldPoint(Input.mousePosition);

        transform.position = new Vector3(mousePosition.x, mousePosition.y, 0f);

        if (mousePosition.y > 0)
        {
            transform.position += new Vector3(0f, -2.5f, 0f);
        }
        else
        {
            transform.position += new Vector3(0f, 2.5f, 0f);
        }
    }
}

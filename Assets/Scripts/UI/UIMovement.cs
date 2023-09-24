using UnityEngine;

public class UIMovement
{
    private Camera _mainCamera;

    public UIMovement()
    {
        _mainCamera = Camera.main;
    }

    public void ReplaceWindow(GameObject panel)
    {
        Vector3 mousePosition = _mainCamera.ScreenToWorldPoint(Input.mousePosition);

        panel.transform.position = new Vector3(mousePosition.x, mousePosition.y, 0f);

        if (mousePosition.y > 0)
        {
            panel.transform.position += new Vector3(0f, -2.5f, 0f);
        }
        else
        {
            panel.transform.position += new Vector3(0f, 2.5f, 0f);
        }
    }
}

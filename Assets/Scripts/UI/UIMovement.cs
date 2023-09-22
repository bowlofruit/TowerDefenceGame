using UnityEngine;
using UnityEngine.EventSystems;

public class UIMovement : MonoBehaviour, IPointerEnterHandler, IPointerExitHandler, IPointerUpHandler, IPointerDownHandler
{
    [SerializeField] private Camera _mainCamera;

    public void OnPointerExit(PointerEventData eventData)
    {
        Debug.Log("Exit");
    }

    public void OnPointerEnter(PointerEventData eventData)
    {
        Debug.Log("Enter");
    }

    public void OnPointerDown(PointerEventData data)
    {
        Debug.Log("Button pressed!");
    }

    public void OnPointerUp(PointerEventData data)
    {
        Debug.Log("Button released!");
    }

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

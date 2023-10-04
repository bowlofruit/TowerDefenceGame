using UnityEngine;
using UnityEngine.UI;

public abstract class ImageToggle : MonoBehaviour
{
    [Header("ButtonSettings")]
    [SerializeField] protected Image _img;
    [SerializeField] protected Button _toggleButton;

    [Header("Sprites")]
    [SerializeField] protected Sprite _activeSprite;
    [SerializeField] protected Sprite _unactiveSrite;

    protected void ToggleSprite(bool isActive)
    {
        if (isActive)
        {
            _img.sprite = _activeSprite;
        }
        else
        {
            _img.sprite = _unactiveSrite;
        }
    }
}
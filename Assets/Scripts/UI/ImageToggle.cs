using UnityEngine;
using UnityEngine.UI;

public class ImageToggle : MonoBehaviour
{
    [Header("Sprites")]
    [SerializeField] private Sprite _activeSprite;
    [SerializeField] private Sprite _unactiveSrite;

    [Header("ButtonSettings")]
    [SerializeField] private Image _img;
    [SerializeField] private Button _toggleButton;

    private bool _isSwitch;

    private void Awake()
    {
        _toggleButton.onClick.AddListener(ToggleSprite);
    }

    private void ToggleSprite()
    {
        if (_isSwitch)
        {
            _img.sprite = _activeSprite;
        }
        else
        {
            _img.sprite = _unactiveSrite;
        }

        _isSwitch = !_isSwitch;
    }
}

using UnityEngine;

public class MusicToggle : ImageToggle
{
    private const string SoundPrefsKey = "SoundOn";
    private bool _isSoundOn;

    private void Awake()
    {
        _isSoundOn = PlayerPrefs.GetInt(SoundPrefsKey, 1) == 1;

        ToggleSprite(_isSoundOn);

        _toggleButton.onClick.AddListener(ToggleSound);
    }

    private void ToggleSound()
    {
        _isSoundOn = !_isSoundOn;
        
        ToggleSprite(_isSoundOn);

        PlayerPrefs.SetInt(SoundPrefsKey, _isSoundOn ? 1 : 0);
        PlayerPrefs.Save();
    }
}

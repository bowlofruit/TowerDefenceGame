using UnityEngine;
using UnityEngine.SceneManagement;

public class LevelCompleteController : MonoBehaviour
{
    public const string COMPLETE_LEVEL_KEY = "CompleteLevels";

    [SerializeField] private GameObject _levelFailedPanel;
    [SerializeField] private GameObject _levelCompeletPanel;

    private void Awake()
    {
        EventController.OnGameOver.AddListener(ShowLevelFailedPanel);
        EventController.OnLevelCompelete.AddListener(ShowLevelCompletePanel);
    }

    private void ShowLevelFailedPanel()
    {
        ShowPanel(_levelFailedPanel);
    }

    private void ShowLevelCompletePanel()
    {
        PlayerPrefs.SetInt(COMPLETE_LEVEL_KEY, SceneManager.GetActiveScene().buildIndex);
        PlayerPrefs.Save();

        Debug.Log(PlayerPrefs.GetInt(COMPLETE_LEVEL_KEY));

        ShowPanel(_levelCompeletPanel);
    }

    private void ShowPanel(GameObject panel)
    {
        panel.SetActive(true);
    }
}

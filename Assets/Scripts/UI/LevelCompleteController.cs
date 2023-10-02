using UnityEngine;

public class LevelCompleteController : MonoBehaviour
{
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
        ShowPanel(_levelCompeletPanel);
    }

    private void ShowPanel(GameObject panel)
    {
        panel.SetActive(true);
    }
}

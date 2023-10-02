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
        ShowPanelAndFreezeGame(_levelFailedPanel);
    }

    private void ShowLevelCompletePanel()
    {
        ShowPanelAndFreezeGame(_levelCompeletPanel);
    }

    private void ShowPanelAndFreezeGame(GameObject panel)
    {
        panel.SetActive(true);
        EventController.OnFreezeGame.Invoke(true);
    }
}

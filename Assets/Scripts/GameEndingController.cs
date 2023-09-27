using UnityEngine;

public class GameEndingController : MonoBehaviour
{
    [SerializeField] private GameObject _gameOverPanel;
    [SerializeField] private GameObject _gameWinPanel;

    private void Awake()
    {
        EventController.OnGameOver.AddListener(() => { _gameOverPanel.SetActive(true); });
        EventController.OnLevelCompelete.AddListener(() => { _gameWinPanel.SetActive(true); });
    }
}

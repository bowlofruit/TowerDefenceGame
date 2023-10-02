using UnityEngine;
using UnityEngine.SceneManagement;

public class UILevelController : MonoBehaviour
{
    public void RestartLevel()
    {
        SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex);
    }

    public void BackToMenu()
    {
        SceneManager.LoadScene(0);
    }

    public void NextLevel()
    {
        SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex + 1);
    }

    public void FreezeTime(bool isFreeze)
    {
        EventController.OnFreezeGame.Invoke(isFreeze);
    }
}

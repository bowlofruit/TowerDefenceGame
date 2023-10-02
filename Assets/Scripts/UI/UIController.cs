using UnityEngine;
using UnityEngine.SceneManagement;

namespace TowerDefence
{
    public class UIController : MonoBehaviour
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
            PlotTowerSettings.IsFreezeTime = isFreeze;

            if (isFreeze)
            {
                Time.timeScale = 0;
            }
            else
            {
                Time.timeScale = 1f;
            }
        }
    }
}
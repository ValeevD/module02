using UnityEngine;
using UnityEngine.SceneManagement;

public class MenuController : MonoBehaviour
{
    public CanvasGroup controlButtons;
    public CanvasGroup restartMenuButtons;

    private void Awake()
    {
        controlButtons.SetVisionTrue();
        restartMenuButtons.SetVisionFalse();
    }

    public void SetGameOver()
    {
        restartMenuButtons.SetVisionTrue();
        controlButtons.SetVisionFalse();
    }

    public void RestartGame()
    {
        SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex);
    }
}

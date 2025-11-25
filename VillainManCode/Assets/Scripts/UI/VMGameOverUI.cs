using UnityEngine;

public class VMGameOverUI : MonoBehaviour
{
    [SerializeField] private GameObject gameOverPanel;

    private bool isShown = false;

    private void Awake()
    {
        if (gameOverPanel != null)
            gameOverPanel.SetActive(false);
    }

    public void ShowGameOver()
    {
        if (isShown) return;
        isShown = true;

        if (gameOverPanel != null)
            gameOverPanel.SetActive(true);
    }

    public void OnRestartButton()
    {
        VMGameManager.Instance?.RestartLevel();
    }

    public void OnQuitButton()
    {
        VMGameManager.Instance?.QuitGame();
    }
}

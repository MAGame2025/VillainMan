using UnityEngine;
using UnityEngine.SceneManagement;

public class VMGameManager : MonoBehaviour
{
    public static VMGameManager Instance { get; private set; }

    public bool IsGameOver { get; private set; }
    public int DestructionScore { get; private set; }   // score

    private void Awake()
    {
        if (Instance != null && Instance != this)
        {
            Destroy(gameObject);
            return;
        }
        Instance = this;
        DontDestroyOnLoad(gameObject);
    }

    public void AddDestructionPoint(int amount = 1)
    {
        DestructionScore += amount;
    }

    public void ResetScore()
    {
        DestructionScore = 0;
    }

    public void OnPlayerDied()
    {
        if (IsGameOver) return;
        IsGameOver = true;
        Time.timeScale = 0f;
    }

    public void RestartLevel()
    {
        Time.timeScale = 1f;
        IsGameOver = false;
        ResetScore();

        Scene scene = SceneManager.GetActiveScene();
        SceneManager.LoadScene(scene.buildIndex);
    }

    public void QuitGame()
    {
        Time.timeScale = 1f;
#if UNITY_EDITOR
        UnityEditor.EditorApplication.isPlaying = false;
#else
        Application.Quit();
#endif
    }
}

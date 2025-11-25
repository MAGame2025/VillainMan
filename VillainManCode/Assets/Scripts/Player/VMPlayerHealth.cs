using UnityEngine;

public class VMPlayerHealth : MonoBehaviour
{
    [SerializeField] private float maxHealth = VMGameConstants.DefaultPlayerMaxHealth;
    [SerializeField] private float currentHealth;

    [Header("References")]
    [SerializeField] private VMGameOverUI gameOverUI;      // 👈 DRAG THIS IN INSPECTOR
    [SerializeField] private VMPlayerController controller; // auto-assigned

    private bool isDead;

    private void Awake()
    {
        if (controller == null)
            controller = GetComponent<VMPlayerController>();
    }

    private void Start()
    {
        currentHealth = maxHealth;
    }

    public void TakeDamage(float amount)
    {
        if (isDead) return;
        if (amount <= 0f) return;

        currentHealth -= amount;
        if (currentHealth <= 0f)
        {
            Die();
        }
    }

    private void Die()
    {
        if (isDead) return;
        isDead = true;

        // Disable movement
        if (controller != null)
            controller.enabled = false;

        // Freeze game
        Time.timeScale = 0f;

        // Trigger Game Over
        if (gameOverUI != null)
        {
            gameOverUI.ShowGameOver();
        }
        else
        {
            Debug.LogWarning("GameOverUI reference missing on VMPlayerHealth!");
        }
    }
}

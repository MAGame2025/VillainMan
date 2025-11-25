using UnityEngine;

public class VMDestructible : MonoBehaviour
{
    [SerializeField] private float maxHealth = 50f;
    [SerializeField] private int scoreValue = 10;

    private float currentHealth;

    private void Start()
    {
        currentHealth = maxHealth;
    }

    public void TakeDamage(float amount)
    {
        if (amount <= 0f) return;

        currentHealth -= amount;
        if (currentHealth <= 0f)
        {
            Die();
        }
    }

    private void Die()
    {
        // +1 destruction point
        if (VMGameManager.Instance != null)
            VMGameManager.Instance.AddDestructionPoint(1);

        Destroy(gameObject);
    }

}

using UnityEngine;

public class VMEnemyHealth : MonoBehaviour
{
    [SerializeField] private float maxHealth = VMGameConstants.DefaultEnemyMaxHealth;
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
            Destroy(gameObject);
        }
    }
}

using UnityEngine;
using UnityEngine.UI;

public class Health : MonoBehaviour
{
    public int maxHealth = 100;
    public int currentHealth;
    public float invulnerableTime = 1f;
    public Slider healthBar;
    public GameManager manager;

    private float cooldown = 0f;

    void Start()
    {
        currentHealth = maxHealth;

        if (healthBar != null)
        {
            healthBar.maxValue = maxHealth;
            UpdateBar();
        }
        else
        {
            Debug.LogWarning("HealthBar is not assigned in the Inspector.", this);
        }
    }

    void Update()
    {
        if (cooldown > 0f)
        {
            cooldown -= Time.deltaTime;
        }
    }

    public void TakeDamage(int amount)
    {
        if (cooldown > 0f || currentHealth <= 0)
        {
            return;
        }

        currentHealth = Mathf.Clamp(currentHealth - amount, 0, maxHealth);
        cooldown = invulnerableTime;

        UpdateBar();

        if (currentHealth == 0)
        {
            if (manager != null)
            {
                manager.EndGame("YOU DIED");
            }
            else
            {
                Debug.LogError("GameManager is not assigned to Health.", this);
            }
        }
    }

    public void Heal(int amount)
    {
        if (currentHealth <= 0)
        {
            return;
        }

        currentHealth = Mathf.Clamp(currentHealth + amount, 0, maxHealth);
        UpdateBar();
    }

    void UpdateBar()
    {
        if (healthBar != null)
        {
            healthBar.value = currentHealth;
        }
    }
}
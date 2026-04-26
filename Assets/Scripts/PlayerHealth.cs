using System.Collections;
using UnityEngine;
using UnityEngine.UI;

public class PlayerHealth : MonoBehaviour
{
    [Header("Health Settings")]
    [SerializeField] int maxHealth = 45;
    [SerializeField] float damageInterval = 0.8f;
    [SerializeField] int damagePerTick = 5;

    [Header("UI")]
    [SerializeField] Slider healthBar;

    int currentHealth;
    bool isTakingDamage = false;    

    void Start()
    {
        currentHealth = maxHealth;

        if (healthBar != null)
        {
            healthBar.maxValue = maxHealth;
            healthBar.value = maxHealth;
        }
    }

    void OnCollisionStay2D(Collision2D collision)
    {
        if (collision.gameObject.CompareTag("Enemy") && !isTakingDamage)
            StartCoroutine(DamageOverTime());
    }

    void OnCollisionExit2D(Collision2D collision)
    {
        if (collision.gameObject.CompareTag("Enemy"))
        {
            StopAllCoroutines();
            isTakingDamage = false;
        }
    }

    IEnumerator DamageOverTime()
    {
        isTakingDamage = true;

        while (isTakingDamage)
        {
            TakeDamage(damagePerTick);
            yield return new WaitForSeconds(damageInterval);
        }
    }

    void TakeDamage(int amount)
    {
        currentHealth = Mathf.Clamp(currentHealth - amount, 0, maxHealth);

        if (healthBar != null)
            healthBar.value = currentHealth;

        if (currentHealth <= 0)
            Die();
    }

    void Die()
    {
        Debug.Log("Player died.");
        // hook up your death/respawn logic here
    }
}
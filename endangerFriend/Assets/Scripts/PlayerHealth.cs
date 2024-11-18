using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerHealth : MonoBehaviour
{
    public int maxHealth = 5; // Maximum health
    private int currentHealth; // Current health

    void Start()
    {
        // Initialize health
        currentHealth = maxHealth;
    }

    public void TakeDamage(int damage)
    {
        // Reduce health by damage amount
        currentHealth -= damage;
        Debug.Log("Player Health: " + currentHealth);

        // Check if health has run out
        if (currentHealth == 0)
        {
            Die();
        }
    }

    void Die()
    {
        Debug.Log("Player has died!");
        Destroy(gameObject); // Destroy the player GameObject
    }
}

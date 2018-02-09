using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Player : MonoBehaviour, IEnemy
{
    private float currentHealth;
    private float maxHealth, power, toughness;

    void Start()
    {
        maxHealth = 30f;
        currentHealth = maxHealth;
    }

    public void PerformAttack()
    {
        throw new System.NotImplementedException();
    }

    public void TakeDamage(int amount)
    {
        currentHealth -= amount;
        if (currentHealth <= 0)
            Die();
        Debug.Log("Aie ! Il me reste seulement " + currentHealth + " HP !");
    }

    void Die()
    {
        Destroy(gameObject);
    }
}

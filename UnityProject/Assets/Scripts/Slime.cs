using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Slime : MonoBehaviour, IEnemy
{
    private float currentHealth;
    public float maxHealth, power, toughness;

    void Start()
    {
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

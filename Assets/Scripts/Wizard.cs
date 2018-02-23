using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Wizard : MonoBehaviour, Character
{
    public int Health { get; set; }
    public int CurrentHealth { get; set; }
    public int Mana { get; set; }
    public int AttackPower { get; set; }
    public int MagicPower { get; set; }
    public int Level { get; set; }
    public int Experience { get; set; }
    public int MouvementSpeed { get; set; }

    public GameObject staff;

    void Start()
    {
        this.Health = 30;
        this.CurrentHealth = 30;
        this.Mana = 10;
        this.AttackPower = 10;
        this.MagicPower = 0;
        this.Level = 1;
        this.Experience = 0;
        this.MouvementSpeed = 10;
    }

    void Update()
    {
        if (Input.GetKeyDown(KeyCode.A))
            staff.GetComponent<Staff>().PerformAttack();
        if (Input.GetKeyDown(KeyCode.E))
            staff.GetComponent<Staff>().PerformSpecialAttack();
    }

    public void TakeDamage(int amount)
    {
        CurrentHealth -= amount;
        if (CurrentHealth <= 0)
            Die();
        Debug.Log("Aie ! Il me reste seulement " + CurrentHealth + " HP !");
    }

    public void Die()
    {
        Destroy(gameObject);
    }
}

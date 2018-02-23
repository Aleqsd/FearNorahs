using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Networking;

public class Warrior : NetworkBehaviour, Character {
    public int Health { get; set; }
    public int CurrentHealth { get; set; }
    public int Mana { get; set; }
    public int AttackPower { get; set; }
    public int MagicPower { get; set; }
    public int Level { get; set; }
    public int Experience { get; set; }
    public int MouvementSpeed { get; set; }

    public GameObject sword;

    void Start () {
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
        if (!isLocalPlayer)
            return;

        if (Input.GetKeyDown(KeyCode.A))
            CmdAttack(); 
        if (Input.GetKeyDown(KeyCode.E))
            sword.GetComponent<Sword>().PerformSpecialAttack();
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

    [Command]
    public void CmdAttack()
    {
        sword.GetComponent<Sword>().PerformAttack();
    }
}

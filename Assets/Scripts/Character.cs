using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public interface Character {
    int Health { get; set; }
    int CurrentHealth { get; set; }
    int Mana { get; set; }
    int AttackPower { get; set; }
    int MagicPower { get; set; }
    int Level { get; set; }
    int Experience { get; set; }
    int MouvementSpeed { get; set; }
    void TakeDamage(int amount);
    void Die();
}

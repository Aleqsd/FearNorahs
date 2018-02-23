using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Networking;

public class Sword : MonoBehaviour, Weapon
{
    public Warrior character;
    private Animator animator;

    void Start()
    {
        animator = GetComponent<Animator>();
        gameObject.GetComponent<NetworkAnimator>().SetParameterAutoSend(0, true);
    }

    public void PerformAttack()
    {
        animator.SetTrigger("Base_Attack");
    }

    public void PerformSpecialAttack()
    {
        animator.SetTrigger("Special_Attack");
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.tag == "Enemy")
            other.GetComponent<Character>().TakeDamage(character.AttackPower);
    }
}
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Networking;

public class Staff : NetworkBehaviour, Weapon
{
    private Animator animator;
    public GameObject fireball;

    public Transform ProjectileSpawn { get; set; }

    void Start()
    {
        animator = GetComponent<Animator>();
    }

    public void PerformAttack()
    {
        animator.SetTrigger("Base_Attack");
    }

    public void PerformSpecialAttack()
    {
        animator.SetTrigger("Special_Attack");
    }

    [Command]
    public void CmdCastProjectile()
    {
        var fireballInstance = (GameObject)Instantiate(fireball, transform.position, transform.rotation);
        fireballInstance.GetComponent<Rigidbody>().velocity = transform.forward * 10f;
        NetworkServer.Spawn(fireballInstance);
    }
}
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Networking;

public class Staff : NetworkBehaviour, IWeapon
{
    private Animator animator;
    public List<BaseStat> Stats { get; set; }
    public GameObject fireball;

    public Transform ProjectileSpawn { get; set; }

    void Start()
    {
        //fireball = Resources.Load<Fireball>("Weapons/Projectiles/Fireball");
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
        fireballInstance.GetComponent<Rigidbody>().velocity = transform.forward*10f;
        NetworkServer.Spawn(fireballInstance);
    }
}

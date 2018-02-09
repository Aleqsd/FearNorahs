using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Staff : MonoBehaviour, IWeapon, IProjectileWeapon
{
    private Animator animator;
    public List<BaseStat> Stats { get; set; }
    Fireball fireball;

    public Transform ProjectileSpawn { get; set; }

    void Start()
    {
        fireball = Resources.Load<Fireball>("Weapons/Projectiles/Fireball");
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

    public void CastProjectile()
    {
        Fireball fireballInstance = (Fireball)Instantiate(fireball, ProjectileSpawn.position, transform.rotation);
        fireballInstance.Direction = ProjectileSpawn.forward;
    }
}

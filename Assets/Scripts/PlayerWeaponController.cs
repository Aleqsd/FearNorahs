using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Networking;

public class PlayerWeaponController : NetworkBehaviour
{

    public GameObject playerHand;
    public GameObject EquippedWeapon { get; set; }

    public GameObject sword;
    public GameObject staff;

    Transform spawnProjectile;
    IWeapon equippedWeapon;
    CharacterStats characterStats;

    private void Start()
    {
        spawnProjectile = transform.Find("ProjectileSpawn");
        characterStats = GetComponent<CharacterStats>();
    }

    
    public void EquipWeapon(Item itemToEquip)
    {
        if (!isLocalPlayer)
            return;

        if (EquippedWeapon != null)
        {
            characterStats.RemoveStatBonus(EquippedWeapon.GetComponent<IWeapon>().Stats);
            Destroy(playerHand.transform.GetChild(0).gameObject);
        }

        if (itemToEquip.ObjectSlug == "sword")
        {
            CmdSpawnSword();
        }
        else
        {
            CmdSpawnStaff();
        }
        equippedWeapon = EquippedWeapon.GetComponent<IWeapon>();
        if (EquippedWeapon.GetComponent<IProjectileWeapon>() != null)
            EquippedWeapon.GetComponent<IProjectileWeapon>().ProjectileSpawn = spawnProjectile;
        equippedWeapon.Stats = itemToEquip.Stats;
        EquippedWeapon.transform.SetParent(playerHand.transform);
        characterStats.AddStatBonus(itemToEquip.Stats);
    }

    [Command]
    public void CmdSpawnSword()
    {
        EquippedWeapon = (GameObject)Instantiate(sword, playerHand.transform.position, playerHand.transform.rotation);
        NetworkServer.SpawnWithClientAuthority(EquippedWeapon,gameObject);
    }

    [Command]
    public void CmdSpawnStaff()
    {
        EquippedWeapon = (GameObject)Instantiate(staff, playerHand.transform.position, playerHand.transform.rotation);
        NetworkServer.Spawn(EquippedWeapon);
    }

    private void Update()
    {
        if (!isLocalPlayer)
            return;

        if (Input.GetKeyDown(KeyCode.A))
            PerformWeaponAttack();
        if (Input.GetKeyDown(KeyCode.E))
            PerformWeaponSpecialAttack();
    }

    public void PerformWeaponAttack()
    {
        equippedWeapon.PerformAttack();
    }

    public void PerformWeaponSpecialAttack()
    {
        equippedWeapon.PerformSpecialAttack();
    }
}


using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Networking;

public class InventoryController : NetworkBehaviour {
    public PlayerWeaponController playerWeaponController;
    public Item sword, staff;

    private void Start()
    {
        playerWeaponController = GetComponent<PlayerWeaponController>();
        List<BaseStat> swordStats = new List<BaseStat>();
        swordStats.Add(new BaseStat(6, "Power", "Your power level."));
        sword = new Item(swordStats,"sword");
        List<BaseStat> staffStats = new List<BaseStat>();
        staffStats.Add(new BaseStat(4, "Power", "Your power level."));
        staff = new Item(staffStats, "staff");
    }

    private void Update()
    {
        if (!isLocalPlayer)
            return;

        if (Input.GetKeyDown(KeyCode.V))
            playerWeaponController.EquipWeapon(sword);

        if (Input.GetKeyDown(KeyCode.B))
            playerWeaponController.EquipWeapon(staff);
    }
}

using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(fileName = "New Weapon", menuName = "Inventory System/Items/Weapons")]
public class Weapons : Items
{
    public float damage;
    public float defenceBonus;
    public float fireRate;
    public int reloadRate;

    public void Awake()
    {
        type = ItemType.Weapons;
    }
}

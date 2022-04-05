using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public enum ItemType
{
    Weapons,
    Coins,
}

public class Items : ScriptableObject
{
    public GameObject itemPrefab;
    public ItemType type;
    public string description; 
}

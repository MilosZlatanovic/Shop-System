using System.Collections;
using System.Collections.Generic;
using UnityEngine;


[CreateAssetMenu(fileName = "New Armor Object", menuName = "Shop System/Items/Armor")]

public class ArmorObject : Item
{
    public int defenseHp;
    private void Awake()
    {
        type = ButtonType.Armor;
    }
}

using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(fileName = "New Weapon Object", menuName = "Shop System/Items/Weapon")]
public class WeaponObject : Item
{
    public int attackHp = 7;
    public void Awake()
    {
        type = ButtonType.Weapons;
    }
}

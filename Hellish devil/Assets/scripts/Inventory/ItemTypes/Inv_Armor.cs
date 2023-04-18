using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using MyGame.Inventory;

[CreateAssetMenu(fileName = "Item", menuName = "MyAssets/Inventory/Create Armor")]
public class Inv_Armor : Inv_Item
{
    public ArmorType Type;
    public float Protection;

    public override void Use()
    {
        base.Use();
    }
}



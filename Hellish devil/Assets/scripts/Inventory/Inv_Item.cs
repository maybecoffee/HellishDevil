using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(fileName = "Item", menuName = "MyAssets/Inventory/Create Item")]
public class Inv_Item : ScriptableObject
{
    public string ID;
    public string Name;
    public Sprite Icon;
    public int MaxStuckAmount;

    public virtual void Use()
    {

    }
}

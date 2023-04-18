using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class OldSword : Weapon
{
    public override float Damage => 10;

    public override float AttackDelay => 0.1f;

    public override float AttackCoolDown => 0.5f;

    public override void Attack()
    {
        Debug.Log(Damage);
    }
}

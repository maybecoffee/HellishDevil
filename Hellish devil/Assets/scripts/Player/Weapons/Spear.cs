using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Spear : Weapon
{
    public override float Damage => 50;

    public override float AttackDelay => 0.4f;

    public override float AttackCoolDown => 0.5f;

    public override void Attack()
    {
        Debug.Log(Damage);
        /*Physics2D.OverlapCircleAll*/
    }
}

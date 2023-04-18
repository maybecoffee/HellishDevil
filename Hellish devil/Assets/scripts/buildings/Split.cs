using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Split : Interactable
{
    public override void Start()
    {
        base.Start();
    }

    override public void Update()
    {
        base.Update();
    }

    public override void Use()
    {
        base.Use();
        CurrentPlayer.GetPlayerStat(PlayerStatsType.Mana).AddValue(1000);
    }
}

using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Goblin : Enemy
{

    public override void Move()
    {
        //base.Move();

        if (this.transform.position.x > target.transform.position.x)
        {
            this.transform.localScale = new Vector3(-startSize.x, startSize.y, startSize.z);
        }

        if (this.transform.position.x < target.transform.position.x)
        {
            this.transform.localScale = startSize;
        }
    }

}

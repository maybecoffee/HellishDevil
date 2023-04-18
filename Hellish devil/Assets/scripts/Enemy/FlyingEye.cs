using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Pathfinding;

public class FlyingEye : Enemy
{
    public override void Update()
    {
        base.Update();
    }

    public override void Move()
    {
        /*Debug.DrawLine(target.transform.position, target.transform.position + TargetOffset, Color.red, 0.001f);*/

        //base.Move();

        if (!isDead) //isDead == false
        {

            if (this.transform.position.x > target.transform.position.x)
            {
                this.transform.localScale = new Vector3(-startSize.x, startSize.y, startSize.z);
            }

            if (this.transform.position.x < target.transform.position.x)
            {
                this.transform.localScale = startSize;
            }

            /*if(Vector3.Distance(this.transform.position, target.transform.position) > StopingDistance)
            {
                this.transform.position = Vector3.Lerp(this.transform.position, target.transform.position + TargetOffset, Time.deltaTime);
                
            }*/



        }
    }

    public override void Die()
    {
        base.Die();

        Rigidbody2D rb = this.gameObject.AddComponent<Rigidbody2D>();
        rb.constraints = RigidbodyConstraints2D.FreezeRotation;
        Destroy(this.GetComponent<AIPath>());
    }

    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.transform.tag == "Ground")
        {
            Destroy(this.GetComponent<Collider2D>());
            Destroy(this.GetComponent<Rigidbody2D>());
        }
    }


}

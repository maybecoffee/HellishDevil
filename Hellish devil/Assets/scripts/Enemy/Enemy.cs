using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Enemy : MonoBehaviour
{
    public bool isDead = false;
    [Header("Animation")]
    private Animator animator;
    public string DieTrigger = "Death";
    public string HitTrigger = "TakeHit";
    [Header("Base")]
    public Player target;
    public float HP = 100;
    public float DMG = 20;
    public float Speed = 5;
    private bool ReadyForAttack = true;
    public float StopingDistance = 2;
    public Vector3 TargetOffset = Vector3.up;
    [SerializeField]
    private float CoolDown = 1;
    public Vector3 startSize;

    private void Start()
    {
        target = FindObjectOfType<Player>();
        startSize = this.transform.localScale;
        animator = this.GetComponentInChildren<Animator>();
    }

    public virtual void Update()
    {
        Move();
    }
    public virtual void Attack()
    {
        Debug.LogError("Attack");
    }

    public virtual void Move()
    {
        
    }

    public virtual void Die()
    {
        isDead = true;
        animator.SetTrigger(DieTrigger);
    }

    public virtual void SetHit(float damage)
    {
        if(isDead == false)
        {
            HP -= damage;

            if(HP <= 0)
            {
                Die();
            }
        }

    }
}

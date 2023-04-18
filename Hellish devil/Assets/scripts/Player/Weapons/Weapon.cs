
using UnityEngine;
public abstract class Weapon : MonoBehaviour
{
    public abstract float Damage { get; }
    public abstract float AttackDelay { get; }
    public abstract float AttackCoolDown { get; }
    public abstract void Attack();
    
}

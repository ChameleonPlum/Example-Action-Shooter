using Photon.Pun;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public abstract class RangeWeapon : IWeapon
{
    private float damage;
    public float Damage
    {
        get
        {
            return damage;
        }

        set
        {
            damage = value;
        }
    }

    private float attackSpeed;
    public float AttackSpeed
    {
        get
        {
            return attackSpeed;
        }

        set
        {
            attackSpeed = value;
        }
    }

    private float attackRange;
    public float AttackRange
    {
        get
        {
            return attackRange;
        }

        set
        {
            attackRange = value;
        }
    }

    private float reloadCoolDown;
    public float ReloadCoolDown
    {
        get
        {
            return reloadCoolDown;
        }

        set
        {
            reloadCoolDown = value;
        }
    }

    public RangeWeapon(JSONObject data)
    {
        Damage = data.GetField("damage").f;
        AttackSpeed = data.GetField("attackSpeed").f;
        AttackRange = data.GetField("attackRange").f;
        ReloadCoolDown = data.GetField("reloadCoolDown").f;
    }

    public virtual void Attack(Vector3 pos, Vector3 rotation)
    {
        
    }

    public abstract void Aim();

}

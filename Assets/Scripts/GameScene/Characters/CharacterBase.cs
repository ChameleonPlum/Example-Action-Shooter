using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CharacterBase
{
    private CharacterData data;

    private float moveSpeed;
    public float MoveSpeed
    {
        get
        {
            return moveSpeed;
        }
        set
        {
            moveSpeed = value;
        }
    }

    private float health;
    public float Health
    {
        get
        {
            return health;
        }
        set
        {
            health = value < 0 ? 0 : value;
        }
    }

    private float rotateSpeed;
    public float RotateSpeed
    {
        get
        {
            return rotateSpeed;
        }
        set
        {
            rotateSpeed = value;
        }
    }

    private int type;
    public int Type
    {
        get
        {
            return type;
        }
        private set
        {
            type = value;
        }
    }


    public CharacterBase(CharacterData _data)
    {
        data = _data;
        Reset();
    }

    public void Reset()
    {
        MoveSpeed = data.GetMoveSpeed;
        Health = data.GetHealth;
        RotateSpeed = data.GetRotateSpeed;
        Type = data.GetType;
    }


}

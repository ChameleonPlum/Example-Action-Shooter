using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CharacterData
{
    public CharacterData(JSONObject data)
    {
        moveSpeed   = data.GetField("moveSpeed").f;
        health      = data.GetField("health").f;
        rotateSpeed = data.GetField("rotateSpeed").f;
        type        = (int)data.GetField("type").i;
    }

    private float moveSpeed;
    public float GetMoveSpeed
    {
        get
        {
            return moveSpeed;
        }
    }

    private float health;
    public float GetHealth
    {
        get
        {
            return health;
        }     
    }

    private float rotateSpeed;
    public float GetRotateSpeed
    {
        get
        {
            return rotateSpeed;
        }        
    }

    private int type;
    public int GetType
    {
        get
        {
            return type;
        }
    }
}

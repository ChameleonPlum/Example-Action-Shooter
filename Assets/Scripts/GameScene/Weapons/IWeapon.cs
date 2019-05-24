using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public interface IWeapon
{
    float Damage { get; set; }
    float AttackSpeed { get; set; }
    float AttackRange { get; set; }

    void Attack(Vector3 pos, Vector3 rotation);
}

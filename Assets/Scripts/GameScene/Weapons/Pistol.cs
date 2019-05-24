using Photon.Pun;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Pistol : RangeWeapon
{
    public Pistol(JSONObject data) : base(data)
    {

    }

    public override void Attack(Vector3 pos, Vector3 rotation)
    {
        base.Attack(pos, rotation);
        BulletFly bullet = PhotonNetwork.Instantiate("Bullet", pos + new Vector3(0, 0.263f, 0), Quaternion.Euler(rotation), 0).GetComponent<BulletFly>();
        bullet.Init(Damage, AttackRange);
    }

    public override void Aim()
    {

    }
}

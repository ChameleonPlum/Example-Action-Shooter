using Photon.Pun;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class WeaponFactory
{
    public IWeapon Create(JSONObject data, Transform parent)
    {
        IWeapon weapon = null;

        int type = (int)data.GetField("type").i;
        switch (type)
        {
            case (int)WeaponType.Pistol:
                object[] d = new object[1];
                d[0] = parent.name;

                GameObject weaponObject = PhotonNetwork.Instantiate("Weapons/Weapon" + type, new Vector3(0, 0, 0), Quaternion.identity, 0, d);
                weapon = new Pistol(data);

                break;
        }
        return weapon;
    }


}

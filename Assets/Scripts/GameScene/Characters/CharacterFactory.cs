using Photon.Pun;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CharacterFactory {

    private WeaponFactory factory = new WeaponFactory();

    public CharacterController Create(JSONObject data, JSONObject weaponData)
    {
        CharacterBase characterData = new CharacterBase(new CharacterData(data));
        CharacterController character = null;

        switch (characterData.Type)
        {
            case (int)CharacterType.Base:
                object[] d = new object[1];
                d[0] = PhotonNetwork.CurrentRoom.PlayerCount.ToString();

                character = PhotonNetwork.Instantiate("Characters/Character" + characterData.Type, new Vector3(10, 2, 10), Quaternion.identity, 0, d).GetComponent<CharacterController>();
                character.name = d[0].ToString();
            break;
        }

        IWeapon weapon = factory.Create(weaponData, character.transform);
        character.Init(characterData, weapon);

        return character;
    }



	
}

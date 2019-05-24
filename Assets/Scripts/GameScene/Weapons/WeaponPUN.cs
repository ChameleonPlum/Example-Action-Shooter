using Photon.Pun;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class WeaponPUN : MonoBehaviour, IPunInstantiateMagicCallback
{
    private string parentName;

    void IPunInstantiateMagicCallback.OnPhotonInstantiate(PhotonMessageInfo info)
    {
        object[] data = this.gameObject.GetPhotonView().InstantiationData;
        if (data != null && data.Length == 1)
        {
            parentName = (string)data[0];
        }

        if (parentName != "" && transform.parent == null)
        {
            Debug.Log("parentName " + parentName);

            if (GameObject.Find(parentName))
            {
                transform.parent = GameObject.Find(parentName).transform;
                GetComponent<PhotonView>().ViewID = transform.parent.gameObject.GetPhotonView().ViewID;
                transform.localPosition = new Vector3(0.84f, -0.073f, 0.463f);
            }
        }
    }
}

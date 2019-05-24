using Photon.Pun;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BulletFly : MonoBehaviour, IPunInstantiateMagicCallback
{
    private float damage;
    private float flyRange;

    public void Init(float _damage, float _attackRange)
    {
        damage = _damage;
        flyRange = _attackRange;

        StartCoroutine(BulletFligt());
    }

    private IEnumerator BulletFligt()
    {
        float distance = flyRange;
        while (distance > 0)
        {
            gameObject.transform.position += transform.forward * Time.deltaTime * 10;
            distance -= Time.deltaTime * 10;
            yield return new WaitForEndOfFrame();
        }

        if (PhotonNetwork.IsMasterClient)
            PhotonNetwork.Destroy(this.gameObject);
    }


    private void OnTriggerEnter(Collider other)
    {
        if (other.tag == "Character")
        {
            other.gameObject.GetComponent<CharacterController>().Damage(damage);
            StopCoroutine(BulletFligt());

            if (PhotonNetwork.IsMasterClient)
                PhotonNetwork.Destroy(this.gameObject);
        }
    }

    void IPunInstantiateMagicCallback.OnPhotonInstantiate(PhotonMessageInfo info)
    {

    }
}

using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AutoTiling : MonoBehaviour {

    private MeshRenderer renderer;

    void Start()
    {
        renderer = GetComponent<MeshRenderer>();

        /*float scaleX = transform.localScale.x;
        float scaleY = transform.localScale.y;
        float scaleZ = transform.localScale.z;*/
        renderer.material.SetTextureScale("_MainTex", transform.localScale);
    }
}

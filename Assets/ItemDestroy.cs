using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ItemDestroy : MonoBehaviour
{
    private GameObject unitychan;

    // Use this for initialization
    void Start()
    {
        //Unityちゃんのオブジェクトを取得
        this.unitychan = GameObject.Find("unitychan");
        //Unityaちゃんとobjectの位置（z座標）の差を求める
    }

    // Update is called once per frame
    void Update()
    {
        if (unitychan.transform.position.z - this.transform.position.z > 0)
        {
            Destroy(this.gameObject);
        }
    }
}

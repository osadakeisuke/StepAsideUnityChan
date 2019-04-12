using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ItemDestroy2 : MonoBehaviour
{
    //Unityちゃんのオブジェクト
    private GameObject unitychan;
    //Unityaちゃんと壁の距離
    private float difference;

    // Use this for initialization
    void Start()
    {
        //Unityちゃんのオブジェクトを取得
        this.unitychan = GameObject.Find("unitychan");
        //Unityaちゃんと壁の位置（z座標）の差を求める
        this.difference = unitychan.transform.position.z - this.transform.position.z;

    }

    // Update is called once per frame
    void Update()
    {
        this.transform.position = new Vector3(0, this.transform.position.y, this.unitychan.transform.position.z - difference);
    }

	private void OnTriggerEnter(Collider other)
	{
        //オブジェクトに壁が衝突した場合
        Destroy(other.gameObject);
	}

}

﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ItemGenerator : MonoBehaviour
{
    //carPrefabを入れる
    public GameObject carPrefab;
    //coinPrefabを入れる
    public GameObject coinPrefab;
    //cornPrefabを入れる
    public GameObject conePrefab;
    //スタート地点
    private float startPos = -200;
    //ゴール地点
    private float gorlPos = 120;
    //アイテムを出すx方向の範囲
    private float posRange = 3.4f;
    //unitychanを入れる
    private GameObject unitychan;

    //この座標を超えた場合にアイテムが生成されるポジション
    public float itemPos = 0;

    // Use this for initialization
    void Start()
    {
        //Unityちゃんのオブジェクトを取得
        this.unitychan = GameObject.Find("unitychan");

        itemPos = startPos;
    }


    // Update is called once per frame
    void Update()
    {
        //一定の距離ごとにアイテムを生成

        if (unitychan.transform.position.z > startPos + itemPos && itemPos < gorlPos - 40)
        {
            Debug.Log("アイテムを生成します " + itemPos.ToString());
            //どのアイテムを出すのかをランダムに設定
            int num = Random.Range(1, 11);
            if (num <= 2)
            {
                //コーンをx軸方向に一直線に生成
                for (float j = -1; j <= 1; j += 0.4f)
                {
                    GameObject cone = Instantiate(conePrefab) as GameObject;
                    cone.transform.position = new Vector3(4 * j, cone.transform.position.y, itemPos + 40);
                }
            }
            else
            {
                //レーンごとにアイテムを生成
                for (int j = -1; j <= 1; j++)
                {
                    //アイテムの種類を決める
                    int item = Random.Range(1, 11);
                    //アイテムを置くZ座標のオフセットをランダムに設定
                    int offsetZ = Random.Range(-5, 6);
                    //60%コイン配置：30%車配置：10%なにもなし
                    if (1 <= item && item <= 6)
                    {
                        //コインを生成
                        GameObject coin = Instantiate(coinPrefab) as GameObject;
                        coin.transform.position = new Vector3(posRange * j, coin.transform.position.y, itemPos + offsetZ + 40);
                    }
                    else if (7 <= item && item <= 9)
                    {
                        //車を生成
                        GameObject car = Instantiate(carPrefab) as GameObject;
                        car.transform.position = new Vector3(posRange * j, car.transform.position.y, itemPos + offsetZ + 40);
                    }

                }
            }
            itemPos += 15;
        }


    }
}
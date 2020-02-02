﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SnapParts : MonoBehaviour
{
    void Start()
    {
        
    }

    void Update()
    {
        
    }
    private void OnTriggerEnter(Collider other)
    {
        if(!other.TryGetComponent(out Rigidbody rigid))
        {
            Debug.LogError("Rigidbodyがアタッチされていません");
            return;
        }
        if(other.tag != "Parts")
        {
            return;
        }
        rigid.useGravity = false;
        rigid.constraints = RigidbodyConstraints.FreezeAll;
        // 座標位置と回転を一致させる
        other.transform.position = this.transform.position;
        other.transform.rotation = this.transform.rotation;
        other.enabled = false;
        // 自身の当たり判定の無効化
        if(TryGetComponent(out Collider collider))
        {
            collider.enabled = false;
        }
    }
}

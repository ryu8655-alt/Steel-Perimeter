using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerBullet : BaseBullet
{
    private void OnTriggerEnter(Collider other)
    {
        //敵に当たったらダメージ処理を行う

        Destroy(gameObject);

    }
}

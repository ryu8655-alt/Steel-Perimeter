using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyBullet : BaseBullet
{

    private void OnTriggerEnter(Collider other)
    {
        //Player・Baseに当たったらダメージ処理を行う

        //Destroy(gameObject);

    }

}

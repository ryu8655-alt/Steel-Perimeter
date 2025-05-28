using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Shooter : MonoBehaviour
{
    [SerializeField, Header("Bullet Prefab")]
    private GameObject _bulletPrefab;

    [SerializeField, Header("発射位置")]
    private Transform _firePosition;

    // Update is called once per frame
    void Update()
    {
        //マウスの左ボタンのクリックで弾を発射する
        if (Input.GetMouseButtonDown(0))
        {
            Shoot();
        }

    }



    private void Shoot()
    {
        if (_bulletPrefab == null || _firePosition == null) return;

        //カメラの向きで発射方向を決定
        Quaternion rotation = Quaternion.LookRotation(transform.forward);
        //弾を生成
        GameObject　bullet =Instantiate(_bulletPrefab, _firePosition.position, rotation);
    
        Collider playerCollider = GetComponent<Collider>();
        Collider bulletCollider = bullet.GetComponent<Collider>();
        if (playerCollider != null && bulletCollider != null)
        {
            Physics.IgnoreCollision(playerCollider, bulletCollider);
        }


    }
}

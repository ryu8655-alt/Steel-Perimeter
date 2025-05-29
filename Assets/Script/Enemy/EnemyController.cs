using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;

public class EnemyController : MonoBehaviour
{
    [SerializeField,Header("目的地(Playerの防衛対象)")]
    private Transform _target;

    [SerializeField, Header("移動速度")]
    private float _moveSpeed = 2.0f;

    [SerializeField,Header("BulletPrefab")]
    private GameObject _bulletPrefab;

    [SerializeField, Header("発射位置")]
    private Transform _shootPosition;

    [SerializeField, Header("射撃のクールダウン")]
    private float _shootCooldown = 2.0f;

    private float _collDownTimer = 0.0f;

    private Rigidbody _rigidbody;

    //後ほどEnemySpawnerでスポーンされた際に行う処理としてIniを用意
    //スポーン時にゲームマネージャを格納し、直接PlayerControlerやTargetの参照を内部に保持しないようにする
    //

    private void Start()
    {
        _rigidbody = GetComponent<Rigidbody>();
    }

    // Update is called once per frame
    private void FixedUpdate()
    {
        if(_target == null)
        {
            Debug.LogWarning("Target is not set. Please assign a target for the enemy to follow.");
            return;
        }

        //目的地に向かって移動
        //目的地への方向ベクトル
        Vector3 direction = (_target.position - transform.position).normalized;

        //移動処理
        Vector3 newRotation = _rigidbody.position + direction * _moveSpeed * Time.fixedDeltaTime;
        _rigidbody.MovePosition(newRotation);

        //敵の向きを目的地に向ける
        if (direction != Vector3.zero)
        {
            Quaternion targetRotation = Quaternion.LookRotation(direction);
            _rigidbody.MoveRotation(targetRotation);
        }


        //クールダウン管理と射撃処理
        _collDownTimer -= Time.fixedDeltaTime;
        Debug.Log($"[Enemy] Cooldown Timer: {_collDownTimer:F2}");
        if (_collDownTimer <= 0.0f)
        {
           
            Shoot();
            _collDownTimer = _shootCooldown; //クールダウンタイマーをリセット
        }

        
    }



    private void Shoot()
    {
        
        if(_bulletPrefab == null || _shootPosition == null)
        {
            Debug.LogWarning("BulletPrefab or ShootPosition is not set. Cannot shoot.");
            return;
        }
        //弾を生成
        GameObject bullet = Instantiate(_bulletPrefab, _shootPosition.position, _shootPosition.rotation);
        //弾の速度を設定
        Collider enemyCol = GetComponent<Collider>();
        Collider bulletCol = bullet.GetComponent<Collider>();

        if(enemyCol!= null && bulletCol != null)
        {
            Physics.IgnoreCollision(enemyCol, bulletCol);
        }
    }
}

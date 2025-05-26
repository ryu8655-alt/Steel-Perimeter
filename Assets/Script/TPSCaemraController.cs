using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TPSCaemraController : MonoBehaviour
{
    public Transform _playerTransform;
    [SerializeField,Header("カメラのオフセット位置")]
    public Vector3 offset = new Vector3(0, 5, -10);

    public float followSpeed = 10f;


    private void FixedUpdate()
    {
        if (_playerTransform == null) return;

        //目標位置を計算する
        Vector3 targetPosition = _playerTransform.position + offset;

        //カメラがプレイヤーを追従するようにする
        transform.position = Vector3.Lerp(transform.position, targetPosition, followSpeed * Time.deltaTime);

        //常にプレイヤーを注視するようにする
        transform.LookAt(_playerTransform);
    }
}

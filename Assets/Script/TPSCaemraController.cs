using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TPSCaemraController : MonoBehaviour
{
    public Transform _playerTransform;
    [SerializeField,Header("カメラのオフセット位置")]
    public Vector3 offset = new Vector3(0, 5, -10);

    public float followSpeed = 10f;

    [Header("マウスの回転速度")]
     public float _mouseSpeed = 3.0f;

    [Header("縦回転の制限")]
    private float _minYAngle = -30f;
    private float _maxYAngle = 60f;

    private float _currentYaw = 10f;//左右回転角度
    private  float _currentPitch = 0f;//上下回転角度


    private void FixedUpdate()
    {
        if (_playerTransform == null) return;


        //マウスの入力を取得してカメラの回転を計算する
        float mouseX = Input.GetAxis("Mouse X") * _mouseSpeed;
        float mouseY = Input.GetAxis("Mouse Y") * _mouseSpeed;
        _currentYaw += mouseX;

        _currentPitch -= mouseY;
        //上下回転の制限を適用する
        _currentPitch = Mathf.Clamp(_currentPitch, _minYAngle, _maxYAngle);

        Quaternion rotation = Quaternion.Euler(_currentPitch, _currentYaw, 0);


        //目標位置を計算する
        Vector3 targetPosition = _playerTransform.position +rotation * offset;

        //カメラがプレイヤーを追従するようにする
        transform.position = Vector3.Lerp(transform.position, targetPosition, followSpeed * Time.deltaTime);

        //常にプレイヤーを注視するようにする
        transform.LookAt(_playerTransform);
    }
}

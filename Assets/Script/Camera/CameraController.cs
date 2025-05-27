using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraController : MonoBehaviour
{
    //追従対象　= Player
    [SerializeField, Header("Player")]
    private Transform _player;
    [SerializeField, Header("マウス感度")]
    private float _mouseSensitivity = 5f;
    [SerializeField, Header("Playerとの距離")]
    private Vector3 _distance = new Vector3(0f, 3f, -5f); 

    [SerializeField, Header("上方向の制限角度")]
    private float _pitchMax = 60f;
    [SerializeField, Header("下方向の制限角度")]
    private float _pitchMin = -30f;

    [SerializeField, Header("左右の回転角")]
    private float _yaw = 0f;

    [SerializeField, Header("上下の回転角")]
    private float _pitch = 0f;

    // Update is called once per frame
    void Update()
    {
        CameraInput();
    }


    private void LateUpdate()
    {
        if (_player == null) return;

        //回転を計算する
        Quaternion rotation = Quaternion.Euler(_pitch, _yaw, 0f);
        Vector3 desiredPosition = _player.position + rotation * _distance;

        //カメラの位置を更新
        transform.position = desiredPosition;
        //カメラの向きを更新
        transform.LookAt(_player); // プレイヤーの頭上を見上げるように調整
    }



    private void CameraInput()
    {
        //マウス入力
        float mouseX = Input.GetAxis("Mouse X");
        float mouseY = Input.GetAxis("Mouse Y");

        _yaw += mouseX * _mouseSensitivity;
        _pitch -= mouseY * _mouseSensitivity;
         _pitch = Mathf.Clamp(_pitch, _pitchMin, _pitchMax);
    }
}

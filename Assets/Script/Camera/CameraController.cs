using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraController : MonoBehaviour
{
    //�Ǐ]�Ώہ@= Player
    [SerializeField, Header("Player")]
    private Transform _player;
    [SerializeField, Header("�}�E�X���x")]
    private float _mouseSensitivity = 5f;
    [SerializeField, Header("Player�Ƃ̋���")]
    private Vector3 _distance = new Vector3(0f, 3f, -5f); 

    [SerializeField, Header("������̐����p�x")]
    private float _pitchMax = 60f;
    [SerializeField, Header("�������̐����p�x")]
    private float _pitchMin = -30f;

    [SerializeField, Header("���E�̉�]�p")]
    private float _yaw = 0f;

    [SerializeField, Header("�㉺�̉�]�p")]
    private float _pitch = 0f;

    // Update is called once per frame
    void Update()
    {
        CameraInput();
    }


    private void LateUpdate()
    {
        if (_player == null) return;

        //��]���v�Z����
        Quaternion rotation = Quaternion.Euler(_pitch, _yaw, 0f);
        Vector3 desiredPosition = _player.position + rotation * _distance;

        //�J�����̈ʒu���X�V
        transform.position = desiredPosition;
        //�J�����̌������X�V
        transform.LookAt(_player); // �v���C���[�̓�������グ��悤�ɒ���
    }



    private void CameraInput()
    {
        //�}�E�X����
        float mouseX = Input.GetAxis("Mouse X");
        float mouseY = Input.GetAxis("Mouse Y");

        _yaw += mouseX * _mouseSensitivity;
        _pitch -= mouseY * _mouseSensitivity;
         _pitch = Mathf.Clamp(_pitch, _pitchMin, _pitchMax);
    }
}

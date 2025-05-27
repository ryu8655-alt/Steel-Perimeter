using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TPSCaemraController : MonoBehaviour
{
    public Transform _playerTransform;
    [SerializeField,Header("�J�����̃I�t�Z�b�g�ʒu")]
    public Vector3 offset = new Vector3(0, 5, -10);

    public float followSpeed = 10f;

    [Header("�}�E�X�̉�]���x")]
     public float _mouseSpeed = 3.0f;

    [Header("�c��]�̐���")]
    private float _minYAngle = -30f;
    private float _maxYAngle = 60f;

    private float _currentYaw = 10f;//���E��]�p�x
    private  float _currentPitch = 0f;//�㉺��]�p�x


    private void FixedUpdate()
    {
        if (_playerTransform == null) return;


        //�}�E�X�̓��͂��擾���ăJ�����̉�]���v�Z����
        float mouseX = Input.GetAxis("Mouse X") * _mouseSpeed;
        float mouseY = Input.GetAxis("Mouse Y") * _mouseSpeed;
        _currentYaw += mouseX;

        _currentPitch -= mouseY;
        //�㉺��]�̐�����K�p����
        _currentPitch = Mathf.Clamp(_currentPitch, _minYAngle, _maxYAngle);

        Quaternion rotation = Quaternion.Euler(_currentPitch, _currentYaw, 0);


        //�ڕW�ʒu���v�Z����
        Vector3 targetPosition = _playerTransform.position +rotation * offset;

        //�J�������v���C���[��Ǐ]����悤�ɂ���
        transform.position = Vector3.Lerp(transform.position, targetPosition, followSpeed * Time.deltaTime);

        //��Ƀv���C���[�𒍎�����悤�ɂ���
        transform.LookAt(_playerTransform);
    }
}

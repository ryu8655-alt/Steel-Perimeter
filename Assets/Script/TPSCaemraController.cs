using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TPSCaemraController : MonoBehaviour
{
    public Transform _playerTransform;
    [SerializeField,Header("�J�����̃I�t�Z�b�g�ʒu")]
    public Vector3 offset = new Vector3(0, 5, -10);

    public float followSpeed = 10f;


    private void FixedUpdate()
    {
        if (_playerTransform == null) return;

        //�ڕW�ʒu���v�Z����
        Vector3 targetPosition = _playerTransform.position + offset;

        //�J�������v���C���[��Ǐ]����悤�ɂ���
        transform.position = Vector3.Lerp(transform.position, targetPosition, followSpeed * Time.deltaTime);

        //��Ƀv���C���[�𒍎�����悤�ɂ���
        transform.LookAt(_playerTransform);
    }
}

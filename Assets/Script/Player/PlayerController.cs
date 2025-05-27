using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerController : MonoBehaviour
{
    [SerializeField, Header("���F�ړ����x")]
    private float _moveSpeed = 5f;

    [SerializeField, Header("�J����Transform")]
    private Transform _cameraTransform; 

    private Rigidbody _rigidbody;
    private Vector3 _input;

    // Start is called before the first frame update
    void Start()
    {
        _rigidbody = GetComponent<Rigidbody>();
    }

    // Update is called once per frame
    void Update()
    {
        MoveInput();
    }

    private void FixedUpdate()
    {
        Move();
    }

    /// <summary>
    /// �v���C���[�̈ړ������̓��͂��擾���A
    /// Vector3�^�̕ϐ��Ɋi�[���܂��B
    /// </summary>
    private void MoveInput()
    {
        float horizontal = Input.GetAxis("Horizontal");
        float vertical = Input.GetAxis("Vertical");
        _input = new Vector3(horizontal, 0, vertical).normalized;
    }


    private void Move()
    {
        if (_cameraTransform == null) return;

        //�J�����̌�������Ɉړ��������v�Z
        Vector3 forward = _cameraTransform.forward;
        Vector3 right = _cameraTransform.right;

        //���������͖������āA���������݂̂ɂ���
        forward.y = 0;
        right.y = 0;
        forward.Normalize();
        right.Normalize();

        //�J��������ɂ����ړ��������v�Z
        Vector3 moveDirection = forward * _input.z + right * _input.x;

        //�ړ�
        Vector3 move = moveDirection.normalized * _moveSpeed;
        _rigidbody.MovePosition(_rigidbody.position + move * Time.fixedDeltaTime);

        //�ړ����͂�����Ƃ��̂݉�]����
        if (moveDirection.sqrMagnitude > 0.01f)
        {
            Quaternion targetRotation = Quaternion.LookRotation(moveDirection);
            _rigidbody.MoveRotation(targetRotation);
        }
    }
}

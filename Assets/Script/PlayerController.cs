using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerController : MonoBehaviour
{
    //�v���C���[�̈ړ����x��ݒ肷��ϐ�
    [SerializeField] 
    private float _moveSpeed = 5f;

    private Rigidbody _rigidbody;

    // Start is called before the first frame update
    void Start()
    {
        _rigidbody = GetComponent<Rigidbody>();
    }

    // Update is called once per frame
    private void FixedUpdate()
    {
        //���͂��擾����
        float horizontalInput = Input.GetAxis("Horizontal");
        float verticalInput = Input.GetAxis("Vertical");

        //�ړ������̃x�N�g�����쐬����
        Vector3 moveDir =new Vector3(horizontalInput, 0, verticalInput).normalized;

        //�V�K�̈ʒu���v�Z����
        Vector3 newPosition = _rigidbody.position + moveDir * _moveSpeed * Time.fixedDeltaTime;
    
        _rigidbody.MovePosition(newPosition);

    }
}

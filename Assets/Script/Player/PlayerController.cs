using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerController : MonoBehaviour
{
    [SerializeField, Header("仮：移動速度")]
    private float _moveSpeed = 5f;

    [SerializeField, Header("カメラTransform")]
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
    /// プレイヤーの移動方向の入力を取得し、
    /// Vector3型の変数に格納します。
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

        //カメラの向きを基準に移動方向を計算
        Vector3 forward = _cameraTransform.forward;
        Vector3 right = _cameraTransform.right;

        //水平方向は無視して、水平成分のみにする
        forward.y = 0;
        right.y = 0;
        forward.Normalize();
        right.Normalize();

        //カメラを基準にした移動方向を計算
        Vector3 moveDirection = forward * _input.z + right * _input.x;

        //移動
        Vector3 move = moveDirection.normalized * _moveSpeed;
        _rigidbody.MovePosition(_rigidbody.position + move * Time.fixedDeltaTime);

        //移動入力があるときのみ回転する
        if (moveDirection.sqrMagnitude > 0.01f)
        {
            Quaternion targetRotation = Quaternion.LookRotation(moveDirection);
            _rigidbody.MoveRotation(targetRotation);
        }
    }
}

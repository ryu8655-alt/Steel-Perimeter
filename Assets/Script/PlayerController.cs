using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerController : MonoBehaviour
{
    //プレイヤーの移動速度を設定する変数
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
        //入力を取得する
        float horizontalInput = Input.GetAxis("Horizontal");
        float verticalInput = Input.GetAxis("Vertical");

        //移動方向のベクトルを作成する
        Vector3 moveDir =new Vector3(horizontalInput, 0, verticalInput).normalized;

        //新規の位置を計算する
        Vector3 newPosition = _rigidbody.position + moveDir * _moveSpeed * Time.fixedDeltaTime;
    
        _rigidbody.MovePosition(newPosition);

    }
}

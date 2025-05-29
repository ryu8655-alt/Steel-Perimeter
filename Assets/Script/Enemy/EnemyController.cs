using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;

public class EnemyController : MonoBehaviour
{
    [SerializeField,Header("�ړI�n(Player�̖h�q�Ώ�)")]
    private Transform _target;

    [SerializeField, Header("�ړ����x")]
    private float _moveSpeed = 2.0f;

    [SerializeField,Header("BulletPrefab")]
    private GameObject _bulletPrefab;

    [SerializeField, Header("���ˈʒu")]
    private Transform _shootPosition;

    [SerializeField, Header("�ˌ��̃N�[���_�E��")]
    private float _shootCooldown = 2.0f;

    private float _collDownTimer = 0.0f;

    private Rigidbody _rigidbody;

    //��ق�EnemySpawner�ŃX�|�[�����ꂽ�ۂɍs�������Ƃ���Ini��p��
    //�X�|�[�����ɃQ�[���}�l�[�W�����i�[���A����PlayerControler��Target�̎Q�Ƃ�����ɕێ����Ȃ��悤�ɂ���
    //

    private void Start()
    {
        _rigidbody = GetComponent<Rigidbody>();
    }

    // Update is called once per frame
    private void FixedUpdate()
    {
        if(_target == null)
        {
            Debug.LogWarning("Target is not set. Please assign a target for the enemy to follow.");
            return;
        }

        //�ړI�n�Ɍ������Ĉړ�
        //�ړI�n�ւ̕����x�N�g��
        Vector3 direction = (_target.position - transform.position).normalized;

        //�ړ�����
        Vector3 newRotation = _rigidbody.position + direction * _moveSpeed * Time.fixedDeltaTime;
        _rigidbody.MovePosition(newRotation);

        //�G�̌�����ړI�n�Ɍ�����
        if (direction != Vector3.zero)
        {
            Quaternion targetRotation = Quaternion.LookRotation(direction);
            _rigidbody.MoveRotation(targetRotation);
        }


        //�N�[���_�E���Ǘ��Ǝˌ�����
        _collDownTimer -= Time.fixedDeltaTime;
        Debug.Log($"[Enemy] Cooldown Timer: {_collDownTimer:F2}");
        if (_collDownTimer <= 0.0f)
        {
           
            Shoot();
            _collDownTimer = _shootCooldown; //�N�[���_�E���^�C�}�[�����Z�b�g
        }

        
    }



    private void Shoot()
    {
        
        if(_bulletPrefab == null || _shootPosition == null)
        {
            Debug.LogWarning("BulletPrefab or ShootPosition is not set. Cannot shoot.");
            return;
        }
        //�e�𐶐�
        GameObject bullet = Instantiate(_bulletPrefab, _shootPosition.position, _shootPosition.rotation);
        //�e�̑��x��ݒ�
        Collider enemyCol = GetComponent<Collider>();
        Collider bulletCol = bullet.GetComponent<Collider>();

        if(enemyCol!= null && bulletCol != null)
        {
            Physics.IgnoreCollision(enemyCol, bulletCol);
        }
    }
}

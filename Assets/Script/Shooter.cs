using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Shooter : MonoBehaviour
{
    [SerializeField, Header("Bullet Prefab")]
    private GameObject _bulletPrefab;

    [SerializeField, Header("���ˈʒu")]
    private Transform _firePosition;

    // Update is called once per frame
    void Update()
    {
        //�}�E�X�̍��{�^���̃N���b�N�Œe�𔭎˂���
        if (Input.GetMouseButtonDown(0))
        {
            Shoot();
        }

    }



    private void Shoot()
    {
        if (_bulletPrefab == null || _firePosition == null) return;

        //�J�����̌����Ŕ��˕���������
        Quaternion rotation = Quaternion.LookRotation(transform.forward);
        //�e�𐶐�
        GameObject�@bullet =Instantiate(_bulletPrefab, _firePosition.position, rotation);
    
        Collider playerCollider = GetComponent<Collider>();
        Collider bulletCollider = bullet.GetComponent<Collider>();
        if (playerCollider != null && bulletCollider != null)
        {
            Physics.IgnoreCollision(playerCollider, bulletCollider);
        }


    }
}

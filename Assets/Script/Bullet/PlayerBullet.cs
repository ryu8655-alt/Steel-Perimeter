using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerBullet : BaseBullet
{
    private void OnTriggerEnter(Collider other)
    {
        //�G�ɓ���������_���[�W�������s��

        Destroy(gameObject);

    }
}

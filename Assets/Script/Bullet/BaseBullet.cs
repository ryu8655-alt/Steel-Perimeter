using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BaseBullet : MonoBehaviour
{
    public float speed = 20f;
    public float lifeTime = 5f;



    // Start is called before the first frame update
    protected virtual void Start()
    {
        Destroy(gameObject, lifeTime);
    }

    protected virtual void Update()
    {
        transform.position += transform.forward * speed * Time.deltaTime;
    }
}

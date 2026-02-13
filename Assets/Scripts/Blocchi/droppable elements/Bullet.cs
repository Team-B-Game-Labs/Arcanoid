using System;
using UnityEngine;

public class Bullet : Drops
{
    public static event Action onBulletHit;
    Rigidbody rb;
    [SerializeField] float speed;
    [SerializeField] GameObject paletta;

    
    private void OnEnable()
    {
        rb = GetComponent<Rigidbody>();
        Vector3 direction = paletta.transform.position - transform.position;
        rb.AddForce(direction.normalized * speed, ForceMode.Impulse);
        transform.rotation = Quaternion.LookRotation(direction);
        //transform. = new Vector3(paletta.transform.position - transform.position);
    }
    
    private void OnCollisionEnter(Collision collision)
    {
        if(collision.gameObject.layer == 7)
        {
            Destroy();
            return;

        }
        if(collision.gameObject.layer == 3)
        {
            onBulletHit?.Invoke();
            GameManager.instance.BulletTake();
            Destroy();
            return;
        }

    }
}

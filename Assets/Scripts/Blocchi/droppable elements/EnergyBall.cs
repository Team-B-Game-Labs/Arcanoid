using UnityEngine;
using System;

public class EnergyBall : Drops         //Simone
{
    public static event Action OnTakeEnergyBall;
    Rigidbody rb;
    [SerializeField] float speed = 3f;

    private void OnEnable()
    {
        rb = GetComponent<Rigidbody>();
        rb.AddForce(Vector3.down * speed, ForceMode.Impulse);
    }
    public override void Collect()
    {
        OnTakeEnergyBall?.Invoke();
        base.Collect();
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
            GameManager.instance.EnergyTake();
            Collect();
            return;
        }
        
    }
}

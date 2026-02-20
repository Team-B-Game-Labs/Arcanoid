using UnityEngine;
using System;

public class GrowthDrop : Drops             //Simone

{
    public static event Action onGrowthDropTake; 

    [SerializeField] float speed = 3f;
    Rigidbody rb;

    private void OnEnable()
    {
        rb = GetComponent<Rigidbody>();
        rb.AddForce(Vector3.down * speed, ForceMode.Impulse);
    }

    public override void Collect()
    {
        onGrowthDropTake?.Invoke();
        base.Collect();
    }

    private void OnCollisionEnter(Collision collision)
    {
        if (collision.gameObject.layer == 7)
        {
            Destroy();
            return;
        }
        if (collision.gameObject.layer == 3)
        {

            Collect();
            return;
        }

    }

}

using UnityEngine;

public class BrickGreenRayCast : MonoBehaviour          //Willy
{
    LayerMask LayerMask;
    RaycastHit hit;

    private void Awake()
    {
        LayerMask = LayerMask.GetMask("Player");
    }
    private void FixedUpdate()
    {
        
    }

    public bool Laser()
    {
        if(Physics.Raycast(transform.position, transform.TransformDirection(Vector3.down), LayerMask))
        {
            Debug.DrawRay(transform.position, transform.TransformDirection(Vector3.down) * hit.distance, Color.green);
            return true;
        }
        else
        {
            Debug.DrawRay(transform.position, transform.TransformDirection(Vector3.down) * 1000, Color.white);
            return false;
        }
    }


}

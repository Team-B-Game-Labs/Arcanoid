using System;
using System.Collections;
using System.Runtime.CompilerServices;
using UnityEngine;

public class Laser : MonoBehaviour
{
    public static event Action onLaserHit;

    [SerializeField] LayerMask layerMask;
    Ray ray;
    RaycastHit hit;
    float timer = 0;
    private void OnEnable()
    {
        
        StartCoroutine(LaserHit());
        
        


        //Transform parent = GetComponentInParent<Transform>();
        //Vector3 posY = new Vector3 (0,parent.position.y, 0);

        //transform.localScale = new Vector3(transform.localScale.x, (posY += new Vector3(, 4.5f, 0)), transform.localScale.z);


    }
    

    private bool laser()
    {
        Transform parent = GetComponentInParent<Transform>();
        float posY = parent.position.y;
        Debug.DrawRay(parent.position, Vector3.down * hit.distance, Color.green);
        if (Physics.Raycast(parent.position, Vector3.down, out hit, (posY += 4.5f), layerMask))
        {
            return true;
        }
        else return false;
    }

    IEnumerator LaserHit()
    {
        while (timer <= 2)
        {
            laser();
            timer += Time.deltaTime;


            if (laser())
            {
                onLaserHit?.Invoke();
                Debug.Log("preso" + layerMask);
                yield return new WaitForSeconds(2f);
            }
           yield return null;
        }

        
       

        Destroy(gameObject);
    }

}

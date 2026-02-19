using System;
using System.Collections;
using UnityEngine;

public class Laser : MonoBehaviour
{
    public static event Action onLaserHit;

    [SerializeField] LayerMask layerMask;
    [SerializeField] GameObject laserObject;
    Ray ray;
    RaycastHit hit;
    Vector3 addY = new Vector3(0, 3.4f, 0);

    
    Transform parent;
    float timer = 0;

    private void Awake()
    {
       parent = GetComponent<Transform>();
       
        
    }
    private void OnEnable()
    {
        StartCoroutine(LaserHit());

        //Get();

       // laserObject = GetComponentInChildren<GameObject>();

        Vector3 plusY = new Vector3(parent.transform.position.x, parent.transform.position.y, parent.transform.position.z);
        if(parent.transform.position.y >= 0.05)
        {
            Instantiate(laserObject, new Vector3(plusY.x, plusY.y -= (addY.y * 2), plusY.z), Quaternion.Euler(0,0,180), parent);
            
        }

        //Transform parent = GetComponentInParent<Transform>();
        //Vector3 posY = new Vector3 (0,parent.position.y, 0);

        //transform.localScale = new Vector3(transform.localScale.x, (posY += new Vector3(, 4.5f, 0)), transform.localScal


    }
    

    private bool laser()
    {
        
        float posY = parent.position.y;
        Debug.DrawRay(parent.position, Vector3.down * hit.distance, Color.green);
        if (Physics.Raycast(parent.position, Vector3.down, out hit, (posY += 10f), layerMask))
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

    //private void Get()
    //{
    //    new WaitForSeconds(0.001f);
    //    laserObject = GetComponentInChildren<GameObject>();
    //}

}

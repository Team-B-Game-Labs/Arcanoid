using System.Collections;
using Unity.VisualScripting;
using UnityEditor.Experimental.GraphView;
using UnityEngine;


public class ClickRaycast : MonoBehaviour
{
    public static ClickRaycast instance;
    public GameObject sphere;
    Camera cam;
    public Vector3 hitPos;
    
    public void Awake()
    {
        if (instance != null)
        {
            Destroy(this);
            return;
        }
        instance = this;

    }
    

    private void Start()
    {
        cam = Camera.main;
        
    }

    public void Update()
    {
        Vector3 clickPos = Input.mousePosition;
        clickPos.z = 9.17f;
        
       Vector3 pointPos = cam.ScreenToWorldPoint(clickPos);
        Debug.DrawLine(transform.position, pointPos, Color.green);
        //Debug.Log(pointPos);
    }

    public void OnClickMove()
    {
       StartCoroutine(MoveToPoint());
        
    }

    IEnumerator MoveToPoint()
    {
        Vector3 mousePos = Input.mousePosition;
        RaycastHit hit;
        Ray ray = cam.ScreenPointToRay(mousePos);
        mousePos.z = 0f;

        if (Physics.Raycast(ray, out hit))
        {
            
            hitPos = hit.point;
            

        }
        

        yield return null;

    }
}

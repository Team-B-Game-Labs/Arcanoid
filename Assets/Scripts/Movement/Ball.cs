using System.Collections;

using Unity.VisualScripting;
using UnityEditor.Experimental.GraphView;
using System;
using UnityEngine;
using UnityEngine.Events;
using UnityEngine.UI;
public class Ball : MonoBehaviour
{
    [SerializeField] private float force = 5.0f;
    [SerializeField] GameObject launchPivot;
    [SerializeField] public Vector3 velocity;
    public float speed;
    Rigidbody rb;
    Vector3 startPos;
    Vector3 newDirection;
    Vector3 lastVelocity;

    //public static event Action <Vector2> OnMouseClick;

    
    bool manualBounceActive;
    bool startLaunchActive;
    private void Start()
    {

        manualBounceActive = false;
        startLaunchActive = false;
        startPos = transform.position;
        rb = GetComponent<Rigidbody>();
        velocity = rb.linearVelocity;
    }
    private void Update()
    {
        speed = rb.linearVelocity.magnitude; //per vedere la speed in inspector
        lastVelocity = rb.linearVelocity;

        ////gestione mouseClick
        //Vector3 clickPos = new Vector3(Input.mousePosition.x, Input.mousePosition.y, 0);

        //clickPos = cam.ScreenToWorldPoint(Input.mousePosition);
        //Debug.DrawRay(Camera.main.transform.position, clickPos, Color.orange);

        if (Input.GetKey(KeyCode.Space) /*&& GameManager.instance.status == GameStatus.GamePaused */)
        {
            StartCoroutine(LaunchDirection());
            Debug.Log("LaunchDirection");
            

        }
        if (Input.GetKeyUp(KeyCode.Space))
        {
            Launch();
            launchPivot.SetActive(false);
            Destroy(launchPivot);
            /* GameManager.instance.status = GameStatus.GameRunning; */


        }



        if (Input.GetMouseButtonDown(0) /* && GameManager.instance.status == GameStatus.GameRunning */ )
        {
            manualBounceActive = true;
            ClickRaycast.instance.OnClickMove();
            newDirection = ClickRaycast.instance.hitPos - transform.position;

            Debug.Log(newDirection);


        }

    }

    public void Launch()
    {



        rb.AddForce(launchPivot.transform.up * force, ForceMode.Impulse);

        Debug.Log("Launch");

    }


    IEnumerator LaunchDirection()
    {
        startLaunchActive = true;
        launchPivot.SetActive(true);

       
       
        
            if (launchPivot.transform.rotation.z >= -80)
            {
                
                launchPivot.transform.rotation *= Quaternion.Euler(0, 0, -1);
                

            }
            else if (launchPivot.transform.rotation.z <= 80) { launchPivot.transform.rotation *= Quaternion.Euler(0, 0, 1); }

        




        yield return null;

    }



    //questa funziona solo con i muri perché gli ho assegnato un layer apposta
    private void OnCollisionEnter(Collision collision)
    {
        float ballSpeed = lastVelocity.magnitude;
        Vector3 ballDirection = Vector3.Reflect(lastVelocity.normalized, collision.contacts[0].normal);
        Vector3 clickPos = Input.mousePosition;
        if ((collision.gameObject.layer == 7 || collision.gameObject.layer == 8) && manualBounceActive == true)
        {
            Debug.Log("muro toccato");


            rb.AddForce(newDirection * force, ForceMode.Force);
            manualBounceActive = false;

        }
        rb.linearVelocity = ballDirection * Mathf.Max(ballSpeed, 0f);
    }
}

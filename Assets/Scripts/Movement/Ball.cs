using System.Collections;



using System;
using UnityEngine;
using Unity.VisualScripting;



public class Ball : MonoBehaviour
{

    public static Ball instance;

    [SerializeField] private float force = 5.0f;
    [SerializeField] GameObject launchPivot;
    [SerializeField] float targetSpeed = 8f;
    public int ballDamage;
    public Vector3 velocity;
    public float ballSpeed;
    Rigidbody rb;


    Vector3 newDirection;
    Vector3 lastVelocity;
    Brick brick;


    [Header("LauncherArrow")]
    [SerializeField] float rotationSpeed = 10f;
    public float maxAngle;




    //public static event Action <Vector2> OnMouseClick;

    bool manualBounceActive;

    private void Awake()
    {
        brick = GetComponent<Brick>();

        if(instance != null)
        {
            Destroy(this);

        }
        instance = this;
    }
    private void Start()
    {
        manualBounceActive = false;

        rb = GetComponent<Rigidbody>();
        velocity = rb.linearVelocity;

    }
    private void Update()
    {
        ballSpeed = rb.linearVelocity.magnitude; //per vedere la speed in inspector
        lastVelocity = rb.linearVelocity;

       
        if (launchPivot != null)
        {



            if (Input.GetKey(KeyCode.Space) /*&& GameManager.instance.status == GameStatus.GamePaused */)
            {
                StartCoroutine(LaunchDirection());
                Debug.Log("LaunchDirection");


            }
            if (Input.GetKeyUp(KeyCode.Space))
            {
                StopAllCoroutines();
                Launch();
                launchPivot.SetActive(false);
                Destroy(launchPivot);
                /* GameManager.instance.status = GameStatus.GameRunning; */



            }
        }



        if (Input.GetMouseButtonDown(0) /* && GameManager.instance.status == GameStatus.GameRunning */ )
        {
            manualBounceActive = true;
            ClickRaycast.instance.OnClickMove();
            newDirection = ClickRaycast.instance.hitPos - ClickRaycast.instance.transform.position;

            Debug.Log(newDirection);


        }

    }

    private void FixedUpdate()
    {
        var v = rb.linearVelocity;
        if (v.sqrMagnitude > 0.0001f)
            rb.linearVelocity = v.normalized * targetSpeed;
    }
    public void Launch()
    {



        rb.AddForce(launchPivot.transform.up * force, ForceMode.Impulse);

        Debug.Log("Launch");

        GameManager.instance.status = GameStatus.GameRunning;

    }


    IEnumerator LaunchDirection()
    {
        launchPivot.SetActive(true);
        float time = 0;

        while (true)
        {
            time += Time.deltaTime * rotationSpeed;

            float rotation = Mathf.PingPong(time, maxAngle * 2) - maxAngle;

            launchPivot.transform.rotation = Quaternion.Euler(0, 0, rotation);
            Debug.Log("rotating");
            yield return null;
        }

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

            //ballDirection = Vector3.MoveTowards(lastVelocity.normalized, newDirection.normalized, Time.deltaTime);

            //rb.AddForce(newDirection.normalized * speed, ForceMode.Impulse);
            ballSpeed = lastVelocity.magnitude;
            
            Vector2 redirectDirection = (newDirection - transform.position).normalized;
            rb.linearVelocity = redirectDirection * ballSpeed;

            manualBounceActive = false;

            return;

        }
        rb.linearVelocity = ballDirection * Mathf.Max(ballSpeed, 0f);

        if (collision.gameObject.TryGetComponent<IBrick>(out IBrick interactable))
            {
                interactable.TakeDamage(ballDamage);
            Debug.Log("damage: " + ballDamage.ToString());
            }
    }

}

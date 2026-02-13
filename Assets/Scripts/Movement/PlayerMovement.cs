using System;
using UnityEngine;


public class PlayerMovement : MonoBehaviour
{
    public static PlayerMovement instance;
    public static event Action ballDamage;

    [SerializeField] private Transform Player;
    [SerializeField] float movementSpeed = 5f;
    [SerializeField] float lateralBound = 4.8f;
    private Vector2 movement;
    Vector2 startPos;
    Vector2 oldPos;

    private void Awake()
    {
        if(instance != null)
        {
            Destroy(this);
            return;
        }
        instance = this;
    }
    private void Start()
    {
        startPos = Player.position;
    }

    private void Update()
    {
       
        
    }
    private void FixedUpdate()
    {
        //if (GameManager.instance.status == GameStatus.GameRunning)
        //    Move();
        // Poi da attivare una volta che il sistema di GeameStatus viene implementato
        Move();
        
        
        movement.Normalize();



    }

    private void Move()
    {
        float xMovement = Input.GetAxis("Horizontal");
        movement.x = xMovement * movementSpeed * Time.fixedDeltaTime;
        transform.Translate(movement);

        if (Mathf.Abs(Player.position.x) >= lateralBound)
        {
            Player.position = new Vector2(Mathf.RoundToInt(oldPos.x), oldPos.y);
        }

        oldPos = Player.position;
    }

    private void OnCollisionEnter(Collision collision)
    {
        if(collision.gameObject.layer == 9)
        {
            ballDamage?.Invoke();
        }
    }

}

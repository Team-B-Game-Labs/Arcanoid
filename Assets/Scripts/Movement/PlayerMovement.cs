using System;
using UnityEngine;



public class PlayerMovement : MonoBehaviour
{
    public static PlayerMovement instance;
    public static event Action ballDamage;

    [SerializeField] private Transform Player;
    [SerializeField] public float movementSpeed = 5f;
    [SerializeField] float lateralBound = 4.8f;
    [SerializeField] Sprite normal;
    [SerializeField] Sprite invincible;

    private Vector2 movement;
    Vector3 startPos;
    Vector2 oldPos;
    SpriteRenderer material;
    private void Awake()
    {
        if(instance != null)
        {
            Destroy(this);
            return;
        }
        instance = this;

        material = GetComponent<SpriteRenderer>();    
        
    }
    private void Start()
    {
        startPos = Player.position;
    }

    private void Update()
    {
        Player.position = new Vector3(Player.position.x, Player.position.y, -0.01f);
        
        if(GameManager.instance.canDamage == false)
        {
            material.sprite = invincible;
        }
        else { material.sprite = normal; }

        if(GameManager.instance.reset == true)
        {
            transform.position = startPos;
        }
    }
    private void FixedUpdate()
    {
        //if (GameManager.instance.status == GameStatus.GameRunning)
        //    Move();
        // Poi da attivare una volta che il sistema di GeameStatus viene implementato
       if(GameManager.instance.status == GameStatus.GameRunning)
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

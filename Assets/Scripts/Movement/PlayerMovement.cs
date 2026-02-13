using UnityEngine;


public class PlayerMovement : MonoBehaviour
{
    [SerializeField] private Transform Player;
    [SerializeField] float movementSpeed = 5f;
    [SerializeField] float lateralBound = 4.8f;
    private Vector2 movement;
    Vector2 startPos;
    Vector2 oldPos;

    private void Start()
    {
        startPos = Player.position;
    }

    private void Update()
    {
        if (Input.GetKeyDown(KeyCode.R))
        {
            Player.position = startPos;
        }
        
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


    
}

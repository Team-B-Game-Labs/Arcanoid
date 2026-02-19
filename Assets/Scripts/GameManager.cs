
using System.Collections;

using UnityEngine;

public enum GameStatus
{
    GameRunning,
    GamePaused,
    GameStopped,
}
public class GameManager : MonoBehaviour
{
    public static GameManager instance;

    [Header("DropBall")]
    [SerializeField] GameObject ball;
    [SerializeField] public GameObject secondaryBall;

    [Header("BallSpeed")]
    [SerializeField] float normalSpeed = 8f;
    [SerializeField] float fasterSpeed = 13f;
    [SerializeField] float overflowSpeed = 20f;

    public GameStatus status;
    [SerializeField] int Energy = 35;
    public int currentEnergy;
    public int maxEnergy = 120;
    public bool canDamage;
    bool overflowConsume;
    public float timer = 0;

    public bool reset;


    private void Awake()
    {
        if (instance != null)
        {
            Destroy(this);
            return;
        }
        instance = this;

        canDamage = true;



    }
    private void OnEnable()
    {
        DropBall.onDropBallTake += DropBallTake;
        PlayerMovement.ballDamage += BallDamage;
        Bullet.onBulletHit += BulletTake;
        GrowthDrop.onGrowthDropTake += GrowthTake;
        Laser.onLaserHit += LaserHit;
        Invincibility.onInvincibilityTake += InvincibilityTake;
    }
    private void OnDisable()
    {
        DropBall.onDropBallTake -= DropBallTake;
        PlayerMovement.ballDamage -= BallDamage;
        Bullet.onBulletHit -= BulletTake;
        GrowthDrop.onGrowthDropTake -= GrowthTake;
        Laser.onLaserHit -= LaserHit;
        Invincibility.onInvincibilityTake -= InvincibilityTake;
    }

    private void Start()
    {
        overflowConsume = false;
        currentEnergy = Energy;
        StartGame();
        Debug.Log(status);
    }

    private void Update() //da reintegrare poi il gamestatus una volta che si hanno tutti i pezzi
    {
        if (status == GameStatus.GamePaused)
        {
            Time.timeScale = 0.0f;

        }
        else Time.timeScale = 1.0f;

        if (status == GameStatus.GameRunning)
        {
            timer += Time.deltaTime;

            if (timer >= 1)
            {

                currentEnergy -= 1;

                timer = 0;

                Debug.Log(currentEnergy);
                return;

            }

            if (currentEnergy >= 120)
            {
                overflowConsume = true;


            }

            if (overflowConsume)
            {
                StartCoroutine(OverflowConsume());
                return;
            }

        }

        while (status == GameStatus.GameRunning)
        {
            if (currentEnergy <= 50)
            {
                Ball.instance.targetSpeed = normalSpeed;
                Ball.instance.ballDamage = 1;
            }

            if (currentEnergy <= 100 && currentEnergy > 50)
            {
                Ball.instance.targetSpeed = fasterSpeed;
                Ball.instance.ballDamage = 2;
            }

            if (currentEnergy <= 120 && currentEnergy > 100)
            {
                Ball.instance.targetSpeed = overflowSpeed;
                Ball.instance.ballDamage = 3;
            }


            return;

        }
    }

    private void FixedUpdate()
    {


    }

    public void StartGame()
    {
        status = GameStatus.GameStopped;
    }

    public void EnergyTake()
    {
        currentEnergy += 25;
        Debug.Log(currentEnergy);
    }

    public void BulletTake()
    {
        if (canDamage == true)
        {
            currentEnergy -= 20;
            Debug.Log(currentEnergy);
        }
    }

    public void DropBallTake()
    {
        Instantiate(secondaryBall, ball.transform.position, Quaternion.identity);
        Instantiate(secondaryBall, ball.transform.position, Quaternion.identity);
        Instantiate(secondaryBall, ball.transform.position, Quaternion.identity);
    }

    public void BallDamage()
    {
        if (canDamage == true)
        {
            currentEnergy -= 35;
            Debug.Log(currentEnergy);
        }
    }

    public void GrowthTake()
    {
        StartCoroutine(Growth());
    }

    IEnumerator Growth()
    {
        Vector3 originalScale;

        originalScale = PlayerMovement.instance.gameObject.transform.localScale;
        float growth = 0.15f;
        PlayerMovement.instance.gameObject.transform.localScale = new Vector3
                                            (originalScale.x += growth, originalScale.y, originalScale.z);
        Debug.Log("Growth");

        yield return new WaitForSeconds(8f);

        PlayerMovement.instance.gameObject.transform.localScale = new Vector3
                                            (originalScale.x -= growth, originalScale.y, originalScale.z);
        Debug.Log("shrink");
        yield return null;
    }

    public void LaserHit()
    {
        StartCoroutine(laserHit());
    }

    IEnumerator laserHit()
    {
        PlayerMovement.instance.movementSpeed -= 5f;

        yield return new WaitForSeconds(6f);

        PlayerMovement.instance.movementSpeed += 5f;

        yield return null;
    }

    public void InvincibilityTake()
    {
        canDamage = false;
        StartCoroutine(invincibTake());

    }

    IEnumerator invincibTake()
    {
        yield return new WaitForSeconds(1.5f);

        canDamage = true;
    }

    IEnumerator OverflowConsume()
    {
        timer += Time.deltaTime * 10;
        if (currentEnergy <= 100)
        {
            overflowConsume = false;

            yield return null;
        }

    }
}

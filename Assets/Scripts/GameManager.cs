using System;
using System.Collections;
using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.InputSystem;
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
    [SerializeField] GameObject secondaryBall;

    public GameStatus status;
    [SerializeField] int Energy;
    public int currentEnergy;
    public int maxEnergy = 120;






    private void Awake()
    {
        if (instance != null)
        {
            Destroy(this);
            return;
        }
        instance = this;

    }
    private void OnEnable()
    {
        DropBall.onDropBallTake += DropBallTake;
        PlayerMovement.ballDamage += BallDamage;
        Bullet.onBulletHit += BulletTake;
        GrowthDrop.onGrowthDropTake += GrowthTake;
        Laser.onLaserHit += LaserHit;
    }
    private void OnDisable()
    {
        DropBall.onDropBallTake -= DropBallTake;
        PlayerMovement.ballDamage -= BallDamage;
        Bullet.onBulletHit -= BulletTake;
        GrowthDrop.onGrowthDropTake -= GrowthTake;
        Laser.onLaserHit -= LaserHit;
    }

    private void Start()
    {
        currentEnergy = Energy;
       status = GameStatus.GamePaused;
    }

    private void Update() //da reintegrare poi il gamestatus una volta che si hanno tutti i pezzi
    {
        //if (status == GameStatus.GamePaused)
        //{
        //    Time.timeScale = 0.0f;

        //}
        //else Time.timeScale = 1.0f;
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
        currentEnergy -= 30;
        Debug.Log(currentEnergy);
    }

    public void DropBallTake()
    {
        Instantiate(secondaryBall, ball.transform.position, Quaternion.identity);
        Instantiate(secondaryBall, ball.transform.position, Quaternion.identity);
        Instantiate(secondaryBall, ball.transform.position, Quaternion.identity);
    }

    public void BallDamage()
    {
        currentEnergy -= 45;
        Debug.Log(currentEnergy);
    }

    public void GrowthTake()
    {
        StartCoroutine(Growth());
    }

    IEnumerator Growth()
    {
        Vector3 originalScale;
        float growth = 0.8f;

        originalScale = PlayerMovement.instance.gameObject.transform.localScale;

        PlayerMovement.instance.gameObject.transform.localScale = new Vector3
                                            (originalScale.x += growth, originalScale.y, originalScale.z);
        Debug.Log("Growth");

      yield return  new WaitForSeconds(8f);

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
}

using System;
using Unity.VisualScripting;
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
    }
    private void OnDisable()
    {
        DropBall.onDropBallTake -= DropBallTake;
        PlayerMovement.ballDamage += BallDamage;
    }

    private void Start()
    {
        currentEnergy = Energy;
        status = GameStatus.GamePaused;
    }

    public void StartGame()
    {
        status = GameStatus.GameRunning;
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
}

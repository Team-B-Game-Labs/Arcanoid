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
        
    }
    private void OnDisable()
    {
        
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
    }
}

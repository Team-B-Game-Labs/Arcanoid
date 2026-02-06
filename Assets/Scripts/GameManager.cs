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
    private void Awake()
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
        status = GameStatus.GamePaused;
    }

    public void StartGame()
    {
        status = GameStatus.GameRunning;
    }
}

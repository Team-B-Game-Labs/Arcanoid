using UnityEngine;
using System.Collections.Generic;
using UnityEngine.SceneManagement;
public class LevelManager : MonoBehaviour
{
    [SerializeField] private int totalBlock;
     private int currentBlock;
    [SerializeField] List<GameObject> Level = new List<GameObject>();
    [SerializeField] List<Scene> Boss = new List<Scene>();
    private int bossLevel;
    int random;
    private GameObject currentLevel;


    private void Start()
    {
        bossLevel = 0;
        currentBlock = totalBlock;

        if (Level.Count > 0)
        {
            random = Random.Range(0, Level.Count);

            currentLevel = Instantiate(Level[random], transform);

            

        }

    }

    private void OnEnable()
    {
        Brick.OnBrickDestroyed += LevelChanger;
        
    }

    private void OnDisable()
    {
        Brick.OnBrickDestroyed -= LevelChanger;
    }

    private void LevelChanger()
    {
        currentBlock--;
        if (currentBlock <= 0 && bossLevel != 3)
        {
            currentBlock = totalBlock;

            Destroy(currentLevel);

            random = Random.Range(0, Level.Count);

            currentLevel = null;

            currentLevel = Instantiate(Level[Random.Range(0, Level.Count)], transform);
            bossLevel++;
            GameManager.instance.reset = true;
            GameManager.instance.status = GameStatus.GameStopped;
        }

        if (currentBlock <= 0 && bossLevel >= 3)
        {
            bossLevel = 0; 
            SceneManager.SetActiveScene(Boss[Random.Range(0, Boss.Count)]);
            GameManager.instance.reset = true;
            GameManager.instance.status = GameStatus.GameStopped;
        }
        
    }
    
}

using UnityEngine;
using System.Collections.Generic;
using UnityEngine.SceneManagement;
public class LevelManager : MonoBehaviour
{
    [SerializeField] private int totalBlock;
    [SerializeField] private int currentBlock;
    [SerializeField] List<GameObject> Level = new List<GameObject>();
    [SerializeField] List<Scene> Boss = new List<Scene>();
    private int bossLevel;
    private GameObject sus;


    private void Start()
    {
        bossLevel = 0;
        currentBlock = totalBlock;
        if (Level.Count > 0)
        {
            Instantiate(Level[Random.Range(0, Level.Count)], transform);

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

            Instantiate(Level[Random.Range(0, Level.Count)], transform);
            
            bossLevel++;
        }

        if (currentBlock <= 0 && bossLevel == 3)
        {
            bossLevel = 0;
            SceneManager.SetActiveScene(Boss[Random.Range(0, Boss.Count)]);
        }
        
    }
    
}

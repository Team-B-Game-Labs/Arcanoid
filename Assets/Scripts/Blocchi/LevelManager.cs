using UnityEngine;
using System.Collections.Generic;
using UnityEngine.SceneManagement;
public class LevelManager : MonoBehaviour               //Willy
{
    [SerializeField] private int totalBlock;
     private int currentBlock;
    [SerializeField] List<GameObject> Level = new List<GameObject>();
    [SerializeField] List<Scene> Boss = new List<Scene>();
    private int bossLevel;
    int random;
    private GameObject currentLevel;
    [SerializeField] GameObject spawnPoint;
    

    private void Start()
    {
        bossLevel = 0;
        currentBlock = totalBlock;

        if (Level.Count > 0)
        {
            random = Random.Range(0, Level.Count);

            currentLevel = Instantiate(Level[random],  new Vector3(spawnPoint.transform.position.x, spawnPoint.transform.position.y, spawnPoint.transform.position.z),transform.localRotation, transform);

            

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
        if (currentBlock <= 0 && bossLevel < 2)
        {
            currentBlock = totalBlock;


            
            Destroy(currentLevel);

            GameObject[] gos = GameObject.FindGameObjectsWithTag("Drops");
            foreach (GameObject go in gos)
                Destroy(go);

            random = Random.Range(0, Level.Count);

            currentLevel = null;

            
            currentLevel = Instantiate(Level[random], new Vector3(spawnPoint.transform.position.x, spawnPoint.transform.position.y, spawnPoint.transform.position.z), transform.localRotation, transform);
            GameManager.instance.canDamage = false;
            GameManager.instance.reset = true;

            GameManager.instance.status = GameStatus.GameStopped;
            bossLevel++;
        }

        if (currentBlock <= 0 && bossLevel >= 2)
        {
            SceneManager.LoadScene(Random.Range(2,5));
            DontDestroyOnLoad(GameManager.instance.gameObject);
            
            bossLevel = 0;
            GameManager.instance.canDamage = false;
            GameManager.instance.reset = true;
            GameManager.instance.status = GameStatus.GameStopped;
        }
        
    }
    
}

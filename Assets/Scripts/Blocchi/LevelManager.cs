using UnityEngine;
using System.Collections.Generic;
public class LevelManager : MonoBehaviour
{
    private int totalBlock;
    private int currentBlock;
    public List<GameObject> Level = new List<GameObject>();
    private GameObject levelSelected;
    private int bossLevel;


    private void Start()
    {
        bossLevel = 1;
        currentBlock = totalBlock;
        if (Level.Count > 0)
        {
            levelSelected = Level[Random.Range(0, Level.Count)];
        }

    }
    private void OnEnable()
    {
        BlockGray.OnBrickDestroyed += LevelChanger;
    }
    private void OnDisable()
    {
        BlockGray.OnBrickDestroyed -= LevelChanger;
    }

    private void LevelChanger()
    {
        currentBlock--;
        if (currentBlock == 0 && bossLevel != 3)
        {
            levelSelected = Level[Random.Range(0, Level.Count)];
            levelSelected.SetActive(true);
            bossLevel++;
        }
    }
}

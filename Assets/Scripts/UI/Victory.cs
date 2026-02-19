using UnityEngine;

public class Victory : MonoBehaviour
{
    [SerializeField] GameObject victoryPanel;

    private void Update()
    {
        if (Boss.instance.currentHp <= 0)
        {
            GotGud();
        }
    }

    private void GotGud()
    {
        victoryPanel.SetActive(true);
        GameManager.instance.status = GameStatus.GamePaused;

    }

}

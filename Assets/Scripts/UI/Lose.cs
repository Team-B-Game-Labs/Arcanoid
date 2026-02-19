using UnityEngine;

public class Lose : MonoBehaviour
{
    [SerializeField] GameObject losePanel;

    private void Update()
    {
        if (GameManager.instance.currentEnergy <= 0)
        {
            GitGud();
        }
    }
        public void GitGud()
    {
        
        
            losePanel.gameObject.SetActive(true);
            PlayerMovement.instance.gameObject.SetActive(false);
            Ball.instance.gameObject.SetActive(false);
            GameManager.instance.status = GameStatus.GamePaused;
        
    }
}


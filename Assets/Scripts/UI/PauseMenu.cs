using UnityEngine;

public class PauseMenu : MonoBehaviour
{
    private void Update()
    {
        if (Input.GetKeyDown(KeyCode.Escape) && GameManager.instance.status == GameStatus.GameRunning)
        {
            UIManager.instance.OpenPauseMenu();
            Debug.Log("Open");
            return;
        }

        if (Input.GetKeyDown(KeyCode.Escape) && GameManager.instance.status == GameStatus.GamePaused)
        {
            UIManager.instance.ClosePauseMenu();
            Debug.Log("Close");

        }



    }
}

using UnityEngine;
using UnityEngine.SceneManagement;

public class SceneStarter : MonoBehaviour
{
    public void PlayButtonsStartGame()
    {
        SceneManager.LoadScene(0);
    }

    public void QuitButtonStartGame()
    {
        Application.Quit();
        
    }

    
    public void ReturnToMainMenu()
    {
        SceneManager.LoadScene(1);
    }
}

using UnityEngine;
using UnityEngine.SceneManagement;

public class SceneStarter : MonoBehaviour
{

    public AudioSource music;

    private void Start()
    {
        music.volume = PlayerPrefs.GetFloat("MusicVolume");
    }

    public void PlayButtonsStartGame()
    {
        SceneManager.LoadScene(1);
    }

    public void QuitButtonStartGame()
    {
        Application.Quit();
        
    }

    
    public void ReturnToMainMenu()
    {
        SceneManager.LoadScene(0);
    }
}

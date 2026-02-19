using UnityEngine;

public class MusicManagers : MonoBehaviour
{
    public AudioSource music;

    private void Start()
    {
        music.volume = PlayerPrefs.GetFloat("MusicVolume");
    }
}

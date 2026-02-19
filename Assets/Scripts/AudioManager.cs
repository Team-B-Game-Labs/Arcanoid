using UnityEngine;
using UnityEngine.UI;

public class AudioManager : MonoBehaviour
{
    public AudioSource music;
    public Slider volume;


    private void Start()
    {
        volume.value = PlayerPrefs.GetFloat("MusicVolume");

    }

    private void Update()
    {
        music.volume = volume.value;
    }

    public void VolumePrefs()
    {
        PlayerPrefs.SetFloat("MusicVolume", music.volume);
    }

    void PlayMusic()
    {
        
    }
}

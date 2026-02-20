using UnityEngine;

public class Audios : MonoBehaviour             //Willy
{
    public AudioSource music;
    public AudioClip musicClip;

    private void Start()
    {
        music.clip = musicClip;
        music.loop = true;
        music.Play();
        
    }
}

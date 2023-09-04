using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MusicScript : MonoBehaviour
{   
    AudioSource gameMusic;
    public static MusicScript instance;
    AudioClip clip;
    private float musicDelay;
    private float musicVolum = 1f; 

    private void Awake() {
        instance = this;
        Debug.Log(MusicButton.get);
        musicDelay = MusicButton.get.delay;
        clip = MusicButton.get.song;
        gameMusic = GetComponent<AudioSource>();
        gameMusic.clip = clip;
    }

    void Start()
    {
        Debug.Log(musicDelay);
        gameMusic.PlayDelayed(musicDelay);

    }

    private void Update()
    {
        gameMusic.volume = musicVolum;
    }

    public void StopMusic() {
        gameMusic.Stop();
    }

    public void SetVolum(float vol)
    {
        musicVolum = vol;
    }

}

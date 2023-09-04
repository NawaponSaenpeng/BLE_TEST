using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SettingDelayMusic : MonoBehaviour
{
    AudioSource gameMusic;
    public float musicDelay;
    private float musicVolum = 1f;

    private void Awake()
    {
        gameMusic = GetComponent<AudioSource>();
    }

    void Start()
    {
        gameMusic.PlayDelayed(musicDelay);

    }

    private void Update()
    {
        gameMusic.volume = musicVolum;
    }

    public void SetVolum(float vol)
    {
        musicVolum = vol;
    }
}

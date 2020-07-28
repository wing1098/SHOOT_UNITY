using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class VolumeController : MonoBehaviour
{
    private AudioSource audioSource;
    private float gameVolume = 0.3f;

    void Start()
    {
        audioSource = GetComponent<AudioSource>();
    }

    private void Update()
    {
        AudioListener.volume = gameVolume;
    }

    public void SettingVolume(float volume)
    {
        gameVolume = volume;
    }
}


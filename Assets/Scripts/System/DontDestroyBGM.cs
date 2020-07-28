using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Rendering;

public class DontDestroyBGM : MonoBehaviour
{

    private AudioSource audioSource;
    private float bgmVolume = 0.3f;

    private void Awake()
    {
        Screen.fullScreen = false;

        audioSource = GetComponent<AudioSource>();
        DontDestroyOnLoad(transform.gameObject);
    }
    private void Update()
    {
        audioSource.volume = bgmVolume;
    }
    public void SettingVolume(float volume)
    {
        bgmVolume = volume;
    }
}

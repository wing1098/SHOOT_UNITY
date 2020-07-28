using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class KeyDoor : MonoBehaviour
{
    [SerializeField] private KeySystem.KeyType keyType;
    [SerializeField] private Animator doorAnimator;

    private AudioSource audioSource;

    private void Start()
    {
        doorAnimator = GetComponent<Animator>();
        audioSource = GetComponent<AudioSource>();
    }

    public KeySystem.KeyType GetKeyType()
    {
        return keyType;
    }

    public void OpenDoor()
    {
        audioSource.Play();
        doorAnimator.SetBool("Open", true);
    }
}

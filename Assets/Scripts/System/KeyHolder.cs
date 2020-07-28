using System;
using System.Collections;
using System.Collections.Generic;
using System.Security.Cryptography;
using UnityEngine;

public class KeyHolder : MonoBehaviour
{
    public event EventHandler OnKeysChanged;

    private List<KeySystem.KeyType> keyList;

    private void Awake()
    {
        keyList = new List<KeySystem.KeyType>();
    }

    public List<KeySystem.KeyType> GetKeyList()
    {
        return keyList;
    }

    public void AddKey(KeySystem.KeyType keyType)
    {
        Debug.Log("Get Key:" + keyType);
        keyList.Add(keyType);
        OnKeysChanged?.Invoke(this, EventArgs.Empty);
    }

    public void RemoveKey(KeySystem.KeyType keyType)
    {
        keyList.Remove(keyType);
        OnKeysChanged?.Invoke(this, EventArgs.Empty);
    }

    public bool ContainsKey(KeySystem.KeyType keyType)
    {
        return keyList.Contains(keyType);
    }

    private void OnTriggerEnter(Collider other)
    {
        KeySystem key = other.GetComponent<KeySystem>();

        if(key != null)
        {
            AddKey(key.GetKeyType());
            Destroy(key.gameObject);
        }

        KeyDoor keyDoor = other.GetComponent<KeyDoor>();
        if (keyDoor != null)
        {
            if(ContainsKey(keyDoor.GetKeyType()))
            {
                //Currently holding key to open this door
                RemoveKey(keyDoor.GetKeyType());
                keyDoor.OpenDoor();
            }
        }
    }
}

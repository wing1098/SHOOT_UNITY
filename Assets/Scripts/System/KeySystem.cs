using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class KeySystem : MonoBehaviour
{
    [SerializeField] private KeyType keyType;

    public enum KeyType
    {
        Red, 
        Green,
    }


    public KeyType GetKeyType()
    {
        return keyType;
    }

    private void Update()
    {
        transform.Rotate(new Vector3(0, 90, 0) * Time.deltaTime, Space.World);
    }
}

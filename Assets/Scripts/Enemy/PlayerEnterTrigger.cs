using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerEnterTrigger : MonoBehaviour
{
    private void OnTriggerEnter(Collider other)
    {
        if(other.CompareTag("Player"))
        {
            EnemyType_S.isTrigger = true;
        }
    }

    private void OnTriggerExit(Collider other)
    {
        if (other.CompareTag("Player"))
        {
            EnemyType_S.isTrigger = false;
        }
    }
}

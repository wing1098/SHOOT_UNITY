using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerEnterTrigger_Boss : MonoBehaviour
{
    private void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Player"))
        {
            EnemyType_Boss.isTrigger = true;
        }
    }
}

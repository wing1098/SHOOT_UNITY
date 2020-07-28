using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DestroyDropLoop : MonoBehaviour
{
    void OnTriggerEnter(Collider other)
    {
        if(other.CompareTag("DropLoopTracker"))
        {
            GameManager.currentMoney += 1;
            Destroy(transform.parent.gameObject);
        }
    }

}

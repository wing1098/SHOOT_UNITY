using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class HurtPlayerBullet : MonoBehaviour
{
    public int damgerToGive;

    public void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.tag == "Player")
        {
            other.GetComponent<PlayerHealthManager>().HurtPlayer(damgerToGive);
            Debug.Log("Hurt");
        }
    }

}

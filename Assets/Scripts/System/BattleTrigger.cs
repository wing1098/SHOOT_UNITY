using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;
using UnityEngine.Experimental.Playables;

public class BattleTrigger : MonoBehaviour
{
    public int nowWeve;
    public event EventHandler OnPlayerEnterTrigger;
    public DoorAnims lastDoor;

    private void OnTriggerEnter(Collider collider)
    {
        PlayerController player = collider.GetComponent<PlayerController>();

        if(player != null)
        {
            GameManager.wave = nowWeve;

            lastDoor.CloseDoor();
            Debug.Log("Player Enemy Trigger");
            OnPlayerEnterTrigger?.Invoke(this, EventArgs.Empty );

            Destroy(gameObject);
        }
    }
}

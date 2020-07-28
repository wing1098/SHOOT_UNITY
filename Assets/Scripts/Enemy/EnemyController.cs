using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyController : MonoBehaviour
{
    private Rigidbody myRigidbody;
    public float moveSpeed;

    public PlayerController thePlayer;

    void Start()
    {
        myRigidbody = GetComponent<Rigidbody>();
        //find the only player
        thePlayer = FindObjectOfType<PlayerController>();
    }

    void Update()
    {
        transform.LookAt(thePlayer.transform.position);
    }

    void FixedUpdate()
    {
        myRigidbody.velocity = (transform.forward * moveSpeed);    
    }
}

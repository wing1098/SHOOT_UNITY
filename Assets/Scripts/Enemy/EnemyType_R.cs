using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyType_R : MonoBehaviour
{
    public float speed;
    public float rushSpeed;
    public float walkDistance;
    public float rushDistance;

    public Transform player;

    static public bool isTrigger;

    public Animator anim;



    private Rigidbody rb;
    void Start()
    {
        player = GameObject.FindGameObjectWithTag("Player").transform;

        rb = GetComponent<Rigidbody>();
        anim = GetComponent<Animator>();
    }

    void Update()
    {
            transform.LookAt(player.transform.position);

            if (Vector3.Distance(transform.position, player.position) > walkDistance)
            {
                anim.SetBool("Walk Forward", true);
                anim.SetBool("Run Forward", false);
                transform.position = Vector3.MoveTowards(transform.position, player.position, speed * Time.deltaTime);
            }

            else if (Vector3.Distance(transform.position, player.position) < rushDistance)
            {
                anim.SetBool("Walk Forward", false);
                anim.SetBool("Run Forward", true);
                //MeleeAttack();
                rb.velocity = Vector3.zero;
                //transform.position = Vector3.MoveTowards(transform.position, player.position, rushSpeed * Time.deltaTime);
            }
    }
}

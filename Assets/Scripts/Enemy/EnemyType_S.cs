using System.Collections;
using System.Collections.Generic;
using System.Security.Permissions;
using UnityEditor;
using UnityEngine;

public class EnemyType_S : MonoBehaviour
{
    public float speed;
    public float stoppingDistance;
    public float retreatDistance;

    private float timeBtwShots;
    public float startTimeBtwShots;

    public float max;
    public float min;

    public GameObject bullet;
    public Transform player;

    public Transform firePoint;

    static public bool isTrigger;

    public Animator anim;

    private AudioSource audioSource;

    void Start()
    {
        audioSource = GetComponent<AudioSource>();
        audioSource.volume = 0.1f;

        player = GameObject.FindGameObjectWithTag("Player").transform;

        timeBtwShots = startTimeBtwShots;

        anim = GetComponent<Animator>();
    }

    void Update()
    {
        if(isTrigger)
        {
            transform.LookAt(player.transform.position);

            //Moving AI
            if(Vector3.Distance(transform.position, player.position) > stoppingDistance)
            {
                anim.SetBool("Run Forward", true);
                transform.position = Vector3.MoveTowards(transform.position, player.position, speed * Time.deltaTime);
            } 
            
            else if(Vector3.Distance(transform.position, player.position) < stoppingDistance && Vector3.Distance(transform.position, player.position) < retreatDistance)
            {
                anim.SetBool("Run Forward", false);
                transform.position = this.transform.position;
            }

            else if(Vector3.Distance(transform.position, player.position) > retreatDistance)
            {
                anim.SetBool("Run Forward", true);
                transform.position = Vector3.MoveTowards(transform.position, player.position, -speed * Time.deltaTime);
            }

            if(timeBtwShots <= 0)
            {
                audioSource.Play();

                Instantiate(bullet, firePoint.position, firePoint.rotation);

                anim.SetBool("Attack 02", true);
                transform.position = this.transform.position;
                //Instantiate(bullet, transform.position, Quaternion.identity);
                timeBtwShots = startTimeBtwShots;
            }
            else
            {
                timeBtwShots -= Time.deltaTime;
            }
        }
        else
            anim.SetBool("Run Forward", false);
    }
}

using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyBullet : MonoBehaviour
{
    bool _isShooting = false;
    public float speed;

    private Transform player;
    private Vector3 target;

    void Start()
    {
        player = GameObject.FindGameObjectWithTag("Player").transform;

        target = new Vector3(player.position.x, player.position.y, player.position.z);
    }

    public void StartShoting()
    {
        _isShooting = true;
    }


    void Update()
    {
        if(_isShooting)
        {
            //transform.position = Vector3.MoveTowards(transform.position, target, speed * Time.deltaTime);
            transform.Translate(Vector3.forward * speed * Time.deltaTime);

            Destroy(gameObject, 3.0f);
            //if (transform.position.x == target.x && transform.position.y == target.y && transform.position.z == target.z)
            //{
            //    DestroyBullet();
            //}
        }


    }

    private void OnTriggerEnter(Collider other)
    {
       if(other.CompareTag("Player"))
        {
            DestroyBullet();
        }
    }

    void DestroyBullet()
    {
        Destroy(gameObject);
    }
}

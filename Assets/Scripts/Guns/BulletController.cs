using System.Collections;
using System.Collections.Generic;
using System.Security.Cryptography;
using UnityEngine;

public class BulletController : MonoBehaviour
{
    public float speed;

    public float lifeTime;

    public int damageToGive;

    public GameObject explosionEffect;
    void Update()
    {
        transform.Translate(Vector3.forward * speed * Time.deltaTime);

        lifeTime -= Time.deltaTime;
        if(lifeTime <= 0)
        {
            Destroy(gameObject);
        }
        //Destroy(gameObject, 3.0f);

    }


    void OnCollisionEnter(Collision other)
    {
        if(other.gameObject.tag == "Enemy")
        {
            //使用EnemyHealthManger中的HurtEnemy令Enemy的血量減少
            GameObject explosion = Instantiate(explosionEffect, transform.position, Quaternion.identity);

            //ContactPoint contact = other.contacts[0];
            //Quaternion rot = Quaternion.FromToRotation(Vector3.up, contact.normal);
            //Vector3 pos = contact.point;

            //var hitVFX = Instantiate(explosionEffect, pos, rot);
            other.gameObject.GetComponent<EnemyHealthManger>().HurtEnemy(damageToGive);
            Destroy(gameObject);
            Destroy(explosion, 1.5f);
            //Destroy(hitVFX, 1.5f);
        }
    }
}

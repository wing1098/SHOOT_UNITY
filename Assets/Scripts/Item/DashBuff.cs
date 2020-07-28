using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DashBuff : MonoBehaviour
{
    public int count;

    public GameObject explosionEffect;
    public HealthBar healthBar;
    private void Update()
    {
        transform.Rotate(new Vector3(0, 40, 0) * Time.deltaTime, Space.World);
    }

    public void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.tag == "Player" && PlayerHealthManager.currentHealth != PlayerHealthManager.maxHealth)
        {
            GameObject explosion = Instantiate(explosionEffect, transform.position, Quaternion.identity);

            PlayerHealthManager.currentHealth += count;
            healthBar.SetHealth(PlayerHealthManager.currentHealth);

            Debug.Log("got Heal");
            Destroy(gameObject);
        }
    }
}

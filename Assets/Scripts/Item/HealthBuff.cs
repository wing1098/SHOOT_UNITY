using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class HealthBuff : MonoBehaviour
{
    public int count;

    public GameObject explosionEffect;
    public HealthBar healthBar;
    public Texture m_MainTexture;

    public Color m_color;
    Renderer m_Renderer;

    private void Start()
    {
        m_Renderer = GetComponent<Renderer>();
        m_Renderer.material.SetTexture("_MainTex", m_MainTexture);
        m_Renderer.material.SetColor("_Color", m_color);
    }

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

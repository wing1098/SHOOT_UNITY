using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ShotgunAmmo : MonoBehaviour
{
    public int ammo;

    public GameObject explosionEffect;
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
        if (other.gameObject.tag == "Player" && ShotGunController.currentAmmo != ShotGunController.maxAmmo)
        {
            GameObject explosion = Instantiate(explosionEffect, transform.position, Quaternion.identity);
            ShotGunController.currentAmmo += ammo;
            Debug.Log("got ammo");
            Destroy(gameObject);

        }
    }
}

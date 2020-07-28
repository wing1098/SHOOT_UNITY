using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PistolAmmo : MonoBehaviour
{
    public int ammo;

    public GameObject explosionEffect;

    public Texture m_MainTexture;

    public Color m_color;
    Renderer m_Renderer;

    private void Start()
    {
        m_color = Color.white;
        m_Renderer = GetComponent<Renderer>();
        m_Renderer.material.SetColor("_Color", m_color);
        m_Renderer.material.SetTexture("_MainTex", m_MainTexture);
    }

    private void Update()
    {
        transform.Rotate(new Vector3(0, 40, 0) * Time.deltaTime, Space.World);
    }

    public void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.tag == "Player" && PistolController.currentAmmo != PistolController.maxAmmo)
        {
            GameObject explosion = Instantiate(explosionEffect, transform.position, Quaternion.identity);
            PistolController.currentAmmo += ammo;
            Debug.Log("got ammo");
            Destroy(gameObject);

        }
    }
}

using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RifleAmmo : MonoBehaviour
{
    public int ammo;

    public GameObject explosionEffect;

    public Texture m_MainTexture;

    static public bool isTrigger;

    public Color m_color = Color.yellow;

    Renderer m_Renderer;

    private void Start()
    {
        m_Renderer = GetComponent<Renderer>();
        m_Renderer.material.SetTexture("_MainTex", m_MainTexture);
    }

    private void Update()
    {
        if(isTrigger)
        {
            m_color = Color.red;
            //this.m_Renderer.material.SetColor("_OutlineColor", m_color);
            this.gameObject.GetComponent<Renderer>().material.SetColor("_OutlineColor", m_color);

        }
        if (!isTrigger)
        {
            m_color = Color.yellow;
            this.gameObject.GetComponent<Renderer>().material.SetColor("_OutlineColor", m_color);
            //this.m_Renderer.material.SetColor("_OutlineColor", m_color);
        }
        transform.Rotate(new Vector3(0, 40, 0) * Time.deltaTime, Space.World);
    }

    public void OnTriggerEnter(Collider other)
    {
        if(other.gameObject.tag == "Player" && RifleController.currentAmmo != RifleController.maxAmmo)
        {
            GameObject explosion = Instantiate(explosionEffect, transform.position, Quaternion.identity);

            RifleController.currentAmmo += ammo;
            Debug.Log("got ammo");
            Destroy(gameObject);

        }
    }
}

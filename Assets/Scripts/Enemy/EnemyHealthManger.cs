using System.Collections;
using System.Collections.Generic;
using System.Security.Cryptography;
using System.Security.Principal;
using UnityEngine;
using UnityEngine.UI;

public class EnemyHealthManger : MonoBehaviour
{
    public int staringHealth;
    public int currentHealth;
    private int getHurtCount;

    public int ponitCount;

    public float flashLength;
    public HealthBar healthBar;

    public GameObject explosionEffect;
    public GameObject floatingTextPrefab;

    public GameObject dropLoopPrefab;

    public Transform player;

    private float flashCounter;

    private Renderer rend;
    private Color storedColor;

    GameObject _dropLoopTracker;

    private AudioSource audioSource;

    void Start()
    {
        gameObject.SetActive(false);

        audioSource = GetComponent<AudioSource>();
        audioSource.volume = 0.5f;

        currentHealth = staringHealth;
        healthBar.SetMaxHealth(staringHealth);

        rend = GetComponent<Renderer>();

        player = GameObject.FindGameObjectWithTag("Player").transform;

        _dropLoopTracker = GameObject.FindGameObjectWithTag("DropLoopTracker");

        //取得預設顏色
        storedColor = rend.material.GetColor("_Color");
    }

    void Update()
    {
        if(currentHealth <= 0)
        {
            Destroy(gameObject);
            GameObject explosion = Instantiate(explosionEffect, transform.position, Quaternion.identity);

            for(int i = 0 ; i < ponitCount; i++)
            {
                var dropLoop = Instantiate(dropLoopPrefab, transform.position + new Vector3(Random.Range(0, 1.5f), Random.Range(0, 1.5f), Random.Range(0, 1.5f)), Quaternion.identity);
                dropLoop.GetComponent<DropLoopFollow>().target = _dropLoopTracker.transform;
            }

            //Dead text
            GameObject deadText = Instantiate(floatingTextPrefab, transform.position, Quaternion.identity);
            deadText.GetComponent<TextMesh>().text = "Dead"; 
            Destroy(explosion, 1.5f);
        }

        if (flashCounter > 0)
        {
            flashCounter -= Time.deltaTime;
            if (flashCounter <= 0)
            {
                this.transform.LookAt(player.transform.position);

                rend.material.SetColor("_Color", storedColor);
            }
        }
    }

    public void HurtEnemy(int damage)
    {
        getHurtCount = damage;
        currentHealth -= damage;
        healthBar.SetHealth(currentHealth);

        audioSource.Play();

        if (floatingTextPrefab != null && currentHealth > 0)
        {
            ShowFloatingText();
        }

        rend.material.SetColor("_Color", Color.red);
        flashCounter = flashLength;
    }

    public bool IsAlive()
    {
        return !IsDead();
    }

    public bool IsDead()
    {
        return currentHealth <= 0;
    }

    public void Spawn()
    {
        Debug.Log("In");
        gameObject.SetActive(true);
        transform.SetParent(null); // Go to root
    }

    void ShowFloatingText()
    {
        var go = Instantiate(floatingTextPrefab, transform.position, Quaternion.identity, transform);
        go.GetComponent<TextMesh>().text = getHurtCount.ToString();
    }
}

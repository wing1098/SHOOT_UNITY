using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class PlayerHealthManager : MonoBehaviour
{
    public int staringHealth;
    public static int maxHealth;
    public static int currentHealth;
    private int getHurtCount;

    public int staringDash;
    public int currentDash;

    public float flashLength;
    public HealthBar healthBar;
    public DashBar dashBar;

    private float flashCounter;

    private Renderer rend;
    private Color storedColor;

    public GameObject floatingTextPrefab;
    public GameObject damage_Image;

    void Start()
    {
        currentHealth = staringHealth;
        maxHealth = staringHealth;
        healthBar.SetMaxHealth(staringHealth);

        currentDash = staringDash;
        dashBar.SetMaxDash(staringDash);

        rend = GetComponent<Renderer>();

        //damage_Image = GetComponent<Image>();
        //取得預設顏色
        storedColor = rend.material.GetColor("_Color");
    }

    void Update()
    {
        healthBar.SetHealth(currentHealth);

        if (currentHealth <= 0)
        {
            gameObject.SetActive(false);
            SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex + 2);

        }

        if (flashCounter > 0)
        {
            flashCounter -= Time.deltaTime;
            if(flashCounter <= 0)
            {
                damage_Image.SetActive(false);
                
                rend.material.SetColor("_Color", storedColor);
            }    
        }
    }

    public void HurtPlayer(int damage)
    {
        getHurtCount = damage;
        currentHealth -= damage;
        healthBar.SetHealth(currentHealth);

        if (floatingTextPrefab != null && currentHealth > 0)
        {
            ShowFloatingText();
        }

        damage_Image.SetActive(true);
        flashCounter = flashLength;
        rend.material.SetColor("_Color", Color.red);
        Debug.Log("Red");
    }

    void ShowFloatingText()
    {
        var go = Instantiate(floatingTextPrefab, transform.position, Quaternion.identity, transform);
        go.GetComponent<TextMesh>().text = getHurtCount.ToString();
    }
}

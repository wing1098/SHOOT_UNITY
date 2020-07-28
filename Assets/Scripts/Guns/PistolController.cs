using System.Collections;
using System.Collections.Generic;
using System.Linq.Expressions;
using System.Security.Cryptography;
using UnityEngine;

public class PistolController : MonoBehaviour
{
    public bool isFiring;

    //Bullet
    public static int maxAmmo = 10;
    public static int currentAmmo;

    //Reload Start
    public float reloadTime = 1.0f;
    private bool isReloading = false;
    
    //Reload animation
    public Animator animator;
    //Bullet prefab
    public BulletController bullet; 
    public float bulletSpeed;
    public static int bulletDamage;

    //Effect
    public GameObject muzzlePrefab;
    public GameObject hitPrefab;

    public float timeBetweenShoot;
    private float shotCounter;
    //Reload End

    //FirePoint

    public Transform firePoint;

    public AudioClip reloadSound;
    private AudioSource audioSource;
    void Start()
    {
        audioSource = GetComponent<AudioSource>();
        audioSource.volume = 0.5f;

        currentAmmo = maxAmmo;
    }

    void OnEnable()
    {
        isReloading = false;
        animator.SetBool("isReloading", false);
    }

    void Update()
    {
        if (isReloading)
            return;

        //if current ammo <= 0 start reload
        if (currentAmmo <= 0)
        {
            StartCoroutine(Reload());
            //Reload();
            return;
        }

        //press r to reload
        if(Input.GetKeyDown(KeyCode.R) && currentAmmo != maxAmmo)
        {
            StartCoroutine(Reload());
            return;
        }

        //shooting
        if (isFiring && currentAmmo > 0)
        {

            shotCounter -= Time.deltaTime;
            if(shotCounter <= 0)
            {
                audioSource.Play();

                currentAmmo--;
                //holdingAmmo--;

                shotCounter = timeBetweenShoot;
                BulletController newBullet = Instantiate(bullet, firePoint.position, firePoint.rotation) as BulletController;

                var muzzleVFX = Instantiate(muzzlePrefab, firePoint.position, firePoint.rotation);
                muzzleVFX.transform.forward = gameObject.transform.forward;

                var hitVFX = Instantiate(hitPrefab, firePoint.position, firePoint.rotation);

                Destroy(muzzleVFX, 1.5f);
                Destroy(hitVFX, 1.5f);

                newBullet.speed = bulletSpeed;
                newBullet.damageToGive += bulletDamage;
            }
        }
        else
        {
            shotCounter = 0;
        }
    }



    IEnumerator Reload()
    {
        isReloading = true;
        Debug.Log("Reloading");

        //reload sound
        audioSource.PlayOneShot(reloadSound);

        //reloading 
        animator.SetBool("isReloading", true);

        yield return new WaitForSeconds(reloadTime - 0.25f);

        //end reloading
        animator.SetBool("isReloading", false);
        
        yield return new WaitForSeconds(0.25f);

        //holdingAmmo = holdingAmmo - currentAmmo;
        currentAmmo = maxAmmo;


        //finish reload function
        isReloading = false;
    }
}

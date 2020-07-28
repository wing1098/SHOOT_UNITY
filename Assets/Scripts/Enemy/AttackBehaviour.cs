using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AttackBehaviour : StateMachineBehaviour
{
    public float speed;
    private Transform playerPos;

    public ParticleSystem dust;

    public bool isFiring;

    public static int maxAmmo = 10;
    public static int currentAmmo;

    public float reloadTime = 1.0f;
    private bool isReloading = false;

    public Animator animator;       //reload animation

    public BulletController bullet; //bullet prefab
    public float bulletSpeed;

    public GameObject muzzlePrefab;
    public GameObject hitPrefab;

    public float timeBetweenShoot;
    private float shotCounter;

    public Transform firePoint;

    override public void OnStateEnter(Animator animator, AnimatorStateInfo stateInfo, int layerIndex)
    {
        playerPos = GameObject.FindGameObjectWithTag("Player").transform;

        isFiring = true;
    }

    override public void OnStateUpdate(Animator animator, AnimatorStateInfo stateInfo, int layerIndex)
    {

        //animator.transform.position = Vector3.MoveTowards(animator.transform.position, playerPos.position, speed * Time.deltaTime);

        if (isFiring)
        {
            shotCounter -= Time.deltaTime;
            if (shotCounter <= 0)
            {
                currentAmmo--;
                //holdingAmmo--;

                shotCounter = timeBetweenShoot;
                BulletController newBullet = Instantiate(bullet, firePoint.position, firePoint.rotation) as BulletController;

                var muzzleVFX = Instantiate(muzzlePrefab, firePoint.position, firePoint.rotation);
                muzzleVFX.transform.forward = animator.transform.forward;

                var hitVFX = Instantiate(hitPrefab, firePoint.position, firePoint.rotation);

                Destroy(muzzleVFX, 1.5f);
                Destroy(hitVFX, 1.5f);

                newBullet.speed = bulletSpeed;
            }
        }
        else
        {
            shotCounter = 0;
        }

        //if (Input.GetKeyDown(KeyCode.Space))
        //{
        //    animator.SetBool("isFollowing", false);
        //}
        //
        //if (Input.GetKeyDown(KeyCode.P))
        //{`
        //    animator.SetBool("isPatrolling", true);
        //}
    }

    // OnStateExit is called when a transition ends and the state machine finishes evaluating this state
    //override public void OnStateExit(Animator animator, AnimatorStateInfo stateInfo, int layerIndex)
    //{
    //    
    //}

    // OnStateMove is called right after Animator.OnAnimatorMove()
    //override public void OnStateMove(Animator animator, AnimatorStateInfo stateInfo, int layerIndex)
    //{
    //    // Implement code that processes and affects root motion
    //}

    // OnStateIK is called right after Animator.OnAnimatorIK()
    //override public void OnStateIK(Animator animator, AnimatorStateInfo stateInfo, int layerIndex)
    //{
    //    // Implement code that sets up animation IK (inverse kinematics)
    //}
}

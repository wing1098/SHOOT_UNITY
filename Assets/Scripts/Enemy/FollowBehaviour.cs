using System.Collections;
using System.Collections.Generic;
using UnityEditor;
using UnityEngine;
using UnityEngine.UI;

public class FollowBehaviour : StateMachineBehaviour
{
    public float speed;
    private Transform playerPos;

    public ParticleSystem dust;
    override public void OnStateEnter(Animator animator, AnimatorStateInfo stateInfo, int layerIndex)
    {
        playerPos = GameObject.FindGameObjectWithTag("Player").transform;
    }

    override public void OnStateUpdate(Animator animator, AnimatorStateInfo stateInfo, int layerIndex)
    {

        animator.transform.position = Vector3.MoveTowards(animator.transform.position, playerPos.position, speed * Time.deltaTime);

        animator.transform.LookAt(playerPos.transform.position);

        dust.Play();

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

    override public void OnStateExit(Animator animator, AnimatorStateInfo stateInfo, int layerIndex)
    {
        
    }

    void CreateDust()
    {
    }

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

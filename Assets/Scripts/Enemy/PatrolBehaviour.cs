using System.Collections;
using System.Collections.Generic;
using System.Runtime.InteropServices.ComTypes;
using System.Threading;
using UnityEngine;

public class PatrolBehaviour : StateMachineBehaviour
{
    private PatrolSpots patrols;
    public float speed;
    private int randomSpot;

    override public void OnStateEnter(Animator animator, AnimatorStateInfo stateInfo, int layerIndex)
    {
        patrols = GameObject.FindGameObjectWithTag("PatrolSpots").GetComponent<PatrolSpots>();
        randomSpot = Random.Range(0, patrols.patrolPoints.Length);
    }

    override public void OnStateUpdate(Animator animator, AnimatorStateInfo stateInfo, int layerIndex)
    {
        if(Vector3.Distance(animator.transform.position, patrols.patrolPoints[randomSpot].position) > 0.2f)
        {
            animator.transform.position = Vector3.MoveTowards(animator.transform.position, patrols.patrolPoints[randomSpot].position, speed * Time.deltaTime);
            animator.transform.LookAt(patrols.patrolPoints[randomSpot].position);
        }
        else
        {
            randomSpot = Random.Range(0, patrols.patrolPoints.Length);
        }
    }

    override public void OnStateExit(Animator animator, AnimatorStateInfo stateInfo, int layerIndex)
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

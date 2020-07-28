//using System.Collections;
//using System.Collections.Generic;
//using UnityEngine;

//public class EnemyControllerType_1 : MonoBehaviour
//{
//    public Animator animator;

//    void Start()
//    {
//       // animator = GetComponent<Animator>();
//    }


//    private void OnTriggerEnter(Collider other)
//    {
//        if (other.gameObject.tag == "Player")
//        {
//            animator.SetBool("isFollowing", true);
//            animator.SetBool("isPatrolling", false);
            
//        }
//    }

//    private void OnTriggerExit(Collider other)
//    {
//        if (other.gameObject.tag == "Player")
//        {
//            animator.SetBool("isFollowing", false);
//            animator.SetBool("isPatrolling", true);
//        }
//    }
//}

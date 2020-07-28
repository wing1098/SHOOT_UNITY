using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GoalTrigger : MonoBehaviour
{
    public GameObject completeLevelUI;

    public Animator anim;

    public GameObject ps;

    private void Start()
    {

    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.tag == "Player")
        {
            //Wave text change to goal 
            GameManager.wave = 4;
            completeLevelUI.SetActive(true);

            anim.SetBool("Jump" , true);

            ps.SetActive(true);

            //animation.Play("Jump");
        }
    }
}

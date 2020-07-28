using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class HurtPlayer : MonoBehaviour
{
    public int damgerToGive;
    [SerializeField]
    private Animator anim;

    //Melee Attack
    public Transform meleeAttackPoint;
    public LayerMask enemyLayers;
    public float meleeAttackRange = 0.5f;
    public int meleeAttackDamage = 1;

    public void OnTriggerEnter(Collider other)
    {
        if(other.gameObject.tag == "Player")
        {
            MeleeAttack();
            Debug.Log("Hurt");
        }
    }

    void MeleeAttack()
    {
        anim.SetTrigger("Attack 01");

        Collider[] hitPlayer = Physics.OverlapSphere(meleeAttackPoint.position, meleeAttackRange, enemyLayers);

        foreach (Collider player in hitPlayer)
        {
            player.GetComponent<PlayerHealthManager>().HurtPlayer(meleeAttackDamage);

            Debug.Log("melee hit player");
        }
    }

    void OnDrawGizmosSelected()
    {
        if (meleeAttackPoint == null)
        {
            return;
        }
        Gizmos.DrawWireSphere(meleeAttackPoint.position, meleeAttackRange);
    }
}

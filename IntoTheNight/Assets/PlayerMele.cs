using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerMele : MonoBehaviour
{
    [SerializeField] GameObject player1;
    private float timeAttack;
    public float startTimeAttack; 
    public Transform attackPos;
    public float attackRange;
    public int damage; 

    
    void Update()
    {
        //Debug.Log("Inside Update");
        if(timeAttack <= 0){
            
            if(Input.GetKey(KeyCode.H)){
                Collider2D[] zombiesToDamage = Physics2D.OverlapCircleAll(attackPos.position, attackRange);
                for(int i = 0; i < zombiesToDamage.Length; i++){
                    zombiesToDamage[i].GetComponent<zombie>().TakeDamage(50);
                    Debug.Log("Delt Damage");
                    player1.GetComponent<player>().points += 25;
                }
            }


            timeAttack = startTimeAttack;
        } else {
            timeAttack -= Time.deltaTime;
        }

        
    }

    void OnDrawGizmosSelected()
    {
        Gizmos.color = Color.red;
        Gizmos.DrawWireSphere(attackPos.position, attackRange);

    }
}

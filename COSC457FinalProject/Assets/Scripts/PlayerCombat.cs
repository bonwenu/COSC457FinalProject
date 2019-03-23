using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerCombat : MonoBehaviour
{
    private float timeBtwAttack;
    public float startTimeBtwAttack;

    public Transform attackPos;
    public LayerMask whatIsEnemy;
    public float attackRange;
    public float damage;


    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()       // Function for player attacking
    {
        if (timeBtwAttack <= 0)
        {
            // time you can attack
            if (Input.GetKey(KeyCode.Space))
            {
                timeBtwAttack = startTimeBtwAttack;
                Collider2D[] enemiesToDamage = Physics2D.OverlapCircleAll(attackPos.position, attackRange, whatIsEnemy);
                for (int i = 0; i < enemiesToDamage.Length; i++)
                {
                    enemiesToDamage[i].GetComponent<EnemyCombat>().TakeDamage(damage);
                }
            }
            
        }
        else
        {
            timeBtwAttack -= Time.deltaTime;
        }
     }
    void OnDrawGizmosSelected() // Methods to sow attack range
    {
        Gizmos.color = Color.red;
        Gizmos.DrawWireSphere(attackPos.position, attackRange);
    }
        
 }

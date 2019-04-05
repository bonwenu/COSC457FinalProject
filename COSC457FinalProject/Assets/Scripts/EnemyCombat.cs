using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyCombat : MonoBehaviour
{
    private float timeBtwAttack;
    public float startTimeBtwAttack = 1.7f;
    public Transform attackPos;
    public LayerMask whatIsEnemy;
    public float attackRange;
    public float damage;
    public float health;            // Set health to (Desired health/100)-0.1
    public float tempHealth ;

    private Animator anime;
    [SerializeField] public HealthBar healthBar;

   
    // Start is called before the first frame update
    void Start()
    {
       
        tempHealth = health;
       
    }

    // Update is called once per frame
    void Update()
    {

        if (timeBtwAttack <= 0)
        {
            // time you can attack
            
            
                timeBtwAttack = startTimeBtwAttack;
                Collider2D[] enemiesToDamage = Physics2D.OverlapCircleAll(attackPos.position, attackRange, whatIsEnemy);
                for (int i = 0; i < enemiesToDamage.Length; i++)
                {
                    enemiesToDamage[i].GetComponent<PlayerCombat>().TakeDamage(damage);
                    
                }
            

        }
        else
        {
            timeBtwAttack -= Time.deltaTime;
        }
        if (health <= 0.0f)
        {
            Destroy(gameObject);
        }
        //transform.Translate(Vector2.left * speed * Time.deltaTime);

        if (health > .01f)
        {


            if (health < .3f)
            {
                healthBar.SetColor(Color.white);


                healthBar.SetColor(Color.red);

            }
        }


    }
    void OnDrawGizmosSelected() // Methods to sow attack range
    {
        Gizmos.color = Color.blue;
        Gizmos.DrawWireSphere(attackPos.position, attackRange);
    }
    public void TakeDamage(float damage)
    {
        healthBar.SetSize(health);
        health -= damage;
        
        if (health <= 0f)
        {
            health = 0f; // Just too make sure its 0
        }
        healthBar.SetSize(health/tempHealth);
        Debug.Log("Enemy took "+ damage*100 + " damage!");
        
    }
}

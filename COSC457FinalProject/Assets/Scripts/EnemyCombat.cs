using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyCombat : MonoBehaviour
{
    
    public GameObject damageEffect;
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
    public void TakeDamage(float damage)
    {
        healthBar.SetSize(health);
        health -= damage;
        
        if (health <= 0f)
        {
            health = 0f; // Just too make sure its 0
        }
        healthBar.SetSize(health/tempHealth);
        Debug.Log("damage Taken !");
        
    }
}

﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class PlayerCombat : MonoBehaviour
{
    private float timeBtwAttack;
    public float startTimeBtwAttack;
    public GameObject blood;
    public Transform attackPos;
    public LayerMask whatIsEnemy;
    public float attackRange;
    public float damage;
    public float health;            // Set health to (Desired health/100)-0.1
    public float tempHealth;
    public AudioClip hitSound;
    public AudioSource hitSource;


    private Animator anime; // >:3c
    [SerializeField] public HealthBar healthBar;


    // Start is called before the first frame update
    void Start()
    {
        tempHealth = health;
        hitSource.clip = hitSound;
    }

    // Update is called once per frame
    void Update()       // Function for player attacking
    {
        healthBar.SetSize(health / tempHealth);
        // damage modifiers
        // now applies modifiers if the player has the item equipped, rather than the item just being in the inventory
        if  (this.GetComponent<PlayerInventory>().inventory[this.GetComponent<PlayerInventory>().selectedItem].CompareTo("Knife") == 0)
        {
            damage = 0.1f;
        }
        else if (this.GetComponent<PlayerInventory>().inventory[this.GetComponent<PlayerInventory>().selectedItem].CompareTo("Bat") == 0)
        {
            damage = 0.135f;
        }
        else if (this.GetComponent<PlayerInventory>().inventory[this.GetComponent<PlayerInventory>().selectedItem].CompareTo("Axe") == 0)
        {
            damage = 0.15f;
        }
        else
        {
            damage = 0.05f;
        }

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
        if (health == 0.0f)
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
        Gizmos.color = Color.red;
        Gizmos.DrawWireSphere(attackPos.position, attackRange);
    }

    public void TakeDamage(float damage)
    {
       hitSource.Play();
        Instantiate(blood, transform.position, Quaternion.identity);
        healthBar.SetSize(health);
        health -= damage;

        if (health <= 0f)
        {
            health = 0f; // Just too make sure its 0
            SceneManager.LoadScene(2);
        }
        healthBar.SetSize(health / tempHealth);
        Debug.Log("You took " + damage*100 +" damage!");

    }

   
}



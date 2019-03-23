﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyCombat : MonoBehaviour
{
    public int health;
    public float speed;
    public GameObject damageEffect;
    private Animator anime;

    // Start is called before the first frame update
    void Start()
    {
        /*anime = GetComponent<Animator>();
        anime.SetBool("isRunning", true);*/
    }

    // Update is called once per frame
    void Update()
    {
        if (health<=0)
        {
            Destroy(gameObject);
        }
        //transform.Translate(Vector2.left * speed * Time.deltaTime);
    }
    public void TakeDamage(int damage)
    {
        health -= damage;
        Debug.Log("damage Taken !");
    }
}

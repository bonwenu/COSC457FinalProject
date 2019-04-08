﻿using UnityEngine;
using System.Collections;
using System.Collections.Generic;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class PlayerController : MonoBehaviour
{
    public float speed;
    private Vector2 moveVelocity;
    private Rigidbody2D rb2d;
    public int count;
    public Text countText;
    public Text winText;

    private Animator anim; 

    //all objects with player controller script will now check this static variable
    private static bool playerExists; //for switching between scenes

    void Start()
    {
        rb2d = GetComponent<Rigidbody2D>();
        count = 0;
        setCountText();
        winText.text = "";

        anim = GetComponent<Animator>(); //makes a connection with the animator 
        
        if(!playerExists)
        {
            playerExists = true;
            DontDestroyOnLoad(transform.gameObject); //keeps player when switching scenes
        }
        else
        {
            Destroy(gameObject);
        }
    }

    void Update()
    {

        Vector2 moveInput = new Vector2(Input.GetAxisRaw("Horizontal"), Input.GetAxisRaw("Vertical"));
        moveVelocity = moveInput.normalized * speed;

        anim.SetFloat("MoveX", Input.GetAxisRaw("Horizontal"));
        anim.SetFloat("MoveY", Input.GetAxisRaw("Vertical"));
    }

    void FixedUpdate()
    {
        rb2d.MovePosition(rb2d.position + moveVelocity * Time.fixedDeltaTime);
    }

    void OnTriggerEnter2D(Collider2D other)
    {
        // If the player runs into a chest...
        if (other.gameObject.CompareTag("Chest"))
        {
            // ...And the chest isn't open already...
            if (!other.gameObject.GetComponent<ChestScript>().isOpen)
            {
                // ...Then set the chest as open,
                other.gameObject.GetComponent<ChestScript>().isOpen = true;
                // Add one to the inventory count,
                count = count + 1;
                // Give the player a random item,
                this.GetComponent<PlayerInventory>().GivePlayerRandomItem();
                // And set the UI text telling the player how many items they have.
                setCountText();
            }
        }
        // If the player runs into the car...
        else if (other.gameObject.CompareTag("Car"))
        {
            // ...And the player has all items...
            if (count >= 4 && this.GetComponent<PlayerInventory>().HasAllItems())
            {
                // ...Then they win!
                winText.text = "You Win!";
                SceneManager.LoadScene(3);
            }
        }

    }

    void setCountText()
    {
        countText.text = "Count: " + count.ToString();
    }
}

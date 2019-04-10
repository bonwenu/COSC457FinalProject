using UnityEngine;
using System.Collections;
using System.Collections.Generic;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class PlayerController : MonoBehaviour
{
    public float speed;
    private Vector2 moveVelocity;
    private Rigidbody2D rb2d;
    public int score;
    public Text scoreText;

    private Animator anim; 

    //all objects with player controller script will now check this static variable
    private static bool playerExists; //for switching between scenes

    void Start()
    {
        rb2d = GetComponent<Rigidbody2D>();
        score = 0;
        setScoreText();

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

    void OnDestroy()
    {
        Debug.Log("GameStatus was destroyed.");
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
                // Add one to the inventory score,
                score = score + 1;
                // Give the player a random item,
                this.GetComponent<PlayerInventory>().GivePlayerRandomItem();
                // And set the UI text telling the player how many items they have.
                setScoreText();
            }
        }
        // If the player runs into the car...
        else if (other.gameObject.CompareTag("Car"))
        {
            // ...And the player has all items...
            if (score >= 4 && this.GetComponent<PlayerInventory>().HasAllItems())
            {
                // ...Then they win!
                SceneManager.LoadScene(3);
            }
        }

    }

    void setScoreText()
    {
        scoreText.text = "Score: " + score.ToString();
    }
}

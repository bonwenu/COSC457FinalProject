using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ChestScript : MonoBehaviour
{
    [Header("Set in Inspector")]
    public Sprite openChest;
    public float interactRange;

    private bool isOpen;

    // Start is called before the first frame update
    void Start()
    {
        isOpen = false;
    }

    // Update is called once per frame
    void Update()
    {

    }

    void OnTriggerEnter2D(Collider2D other)
    {
        if (other.gameObject.CompareTag("Player"))
        {
            // Sprite is changed to an open chest when chest is opened
            this.GetComponent<SpriteRenderer>().sprite = openChest;
            // Chest is now open
            isOpen = true;
        }

    }
}

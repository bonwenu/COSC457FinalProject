using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BuildingView : MonoBehaviour
{
    private Renderer rend;
    private int sortingOrderBase;

    [Header("Set in Inspector")]
    public Sprite image1;
    public Sprite image2;

    // Start is called before the first frame update
    void Awake()
    {
        rend = gameObject.GetComponent<Renderer>();
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    void OnTriggerStay2D(Collider2D other)
    {
        if (other.gameObject.CompareTag("Player"))
        {
            // Sprite is changed to inside of the house
            this.GetComponent<SpriteRenderer>().sprite = image2;
            rend.sortingOrder = sortingOrderBase - 2; 
        }
    }

    void OnTriggerExit2D(Collider2D other)
    {
        if (other.gameObject.CompareTag("Player"))
        {
            // Sprite is changed to inside of the house
            this.GetComponent<SpriteRenderer>().sprite = image1;
            sortingOrderBase = 3;
            rend.sortingOrder = sortingOrderBase;
        }
    }
}

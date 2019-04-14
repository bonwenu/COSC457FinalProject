using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BuildingView : MonoBehaviour
{

    [Header("Set in Inspector")]
    public Sprite image1;
    public Sprite image2;

    // Start is called before the first frame update
    void Start()
    {

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
            transform.Translate(0, 0, 4);
        }
    }

    void OnTriggerExit2D(Collider2D other)
    {
        if (other.gameObject.CompareTag("Player"))
        {
            // Sprite is changed to inside of the house
            this.GetComponent<SpriteRenderer>().sprite = image1;
            transform.Translate(0, 0, -4);
        }
    }
}

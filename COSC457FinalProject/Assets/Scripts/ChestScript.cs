using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ChestScript : MonoBehaviour
{
    [Header("Set in Inspector")]
    public Sprite openChest;
    public float interactRange;

    // Start is called before the first frame update
    void Start()
    {
        
        this.GetComponent<SpriteRenderer>().sprite = openChest;
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}

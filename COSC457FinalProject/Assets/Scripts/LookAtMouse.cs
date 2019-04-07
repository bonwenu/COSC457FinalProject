using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LookAtMouse : MonoBehaviour
{
   
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        Flip();
    }
    void Flip() //Flips player based on mouse's position relative to it's center.
    {
        Vector3 theScale = transform.localScale;
        Vector3 pos = new Vector3(Input.mousePosition.x, Input.mousePosition.y, 0);
        float WorldXPos = Camera.main.ScreenToWorldPoint(pos).x; //Converts screen point to point in world

        if (WorldXPos > gameObject.transform.position.x)
        {
            theScale.x = -2;
            transform.localScale = theScale;
            
        }

        else
        {
            theScale.x = 2;
            transform.localScale = theScale;
        }

    }
}

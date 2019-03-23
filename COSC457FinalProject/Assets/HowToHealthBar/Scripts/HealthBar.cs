using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class HealthBar : MonoBehaviour {

    public Transform bar;

	public void Awake () {
        bar = transform.Find("Bar");
        
	}
    
    public void SetSize(float sizeNormalized) {
        if (sizeNormalized<=0f)
        {
            sizeNormalized = 0; // Just too make sure its 0
        }
        if (bar.localScale == new Vector3(0f, 1f))
        {
            Destroy(gameObject);
        }
        bar.localScale = new Vector3(sizeNormalized, 1f);
       
        
    }

    public void SetColor(Color color) {
        bar.Find("BarSprite").GetComponent<SpriteRenderer>().color = color;
    }
}

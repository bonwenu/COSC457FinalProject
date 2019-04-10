using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraController : MonoBehaviour
{

    public GameObject player;
    private Vector3 offset;
    private bool cameraExists;

    // Start is called before the first frame update
    void Start()
    {
        offset = transform.position - player.transform.position;

        if (!cameraExists)
        {
            cameraExists = true;
            DontDestroyOnLoad(transform.gameObject); //keeps player when switching scenes
        }
        else
        {
            Destroy(gameObject);
        }

    }
    
    // Update is called once per frame
    void LateUpdate()
    {
        transform.position = player.transform.position + offset;
        
    }

}

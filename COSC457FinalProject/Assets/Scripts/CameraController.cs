using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraController : MonoBehaviour
{

    public GameObject player;
    private Vector3 offset;
    private bool cameraExists;
    public int minX;
    public int maxX;
    public int minY;
    public int maxY;

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
        if (player.transform.position.x > minX && player.transform.position.x < maxX && player.transform.position.y > minY && player.transform.position.y < maxY)
        {
            transform.position = player.transform.position + offset;
        }
        //transform.position = player.transform.position + offset;
        
    }

}

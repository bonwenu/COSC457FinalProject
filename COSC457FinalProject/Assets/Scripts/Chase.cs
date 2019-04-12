using UnityEngine;
using System.Collections;

public class Chase : MonoBehaviour
{

    public int speed;
    public GameObject target;
    private Animator anim;

    void Start()
    {
        target = GameObject.FindGameObjectWithTag("Player");
        anim = GetComponent<Animator>();
        DontDestroyOnLoad(transform.gameObject); //keeps player when switching scene
    }

    void Update()
    {
        Vector3 localPosition = target.transform.position - transform.position;

        localPosition = localPosition.normalized; // The normalized direction in LOCAL space
        transform.Translate(localPosition.x * Time.deltaTime * speed, localPosition.y * Time.deltaTime * speed, localPosition.z * Time.deltaTime * speed);
    }
}
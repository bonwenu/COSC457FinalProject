using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CarScene : MonoBehaviour
{
    public float movementSpeed = 200;
    public AudioClip carSound;
    public AudioSource carSource;

    void Start()
    {
        carSource.clip = carSound;
        carSource.Play();
    }
    void Update()
    {

        transform.Translate(Vector3.left * movementSpeed * Time.deltaTime);

    }
}
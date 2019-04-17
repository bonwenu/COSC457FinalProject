﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Gun : MonoBehaviour
{
    public float offset;

    public GameObject projectile;
    public GameObject gunFire;
    public Transform shotPoint;

    private float timeBtwnShots;
    public float startTimeBtwnShots;
    public GameObject player;
    // Start is called before the first frame update
    void Start()
    {
        projectile.SetActive(false);
        gunFire.SetActive(false);
        //projectile.SetActive(false);
    }

    // Update is called once per frame
    void Update()
    {
        // now gun is only active if it is equipped
        if (player.GetComponent<PlayerInventory>().inventory[player.GetComponent<PlayerInventory>().selectedItem].CompareTo("Gun") == 0)
        {
            projectile.SetActive(true);
            gunFire.SetActive(true);
            Debug.Log("Gun is active");
        }
        else
        {
            projectile.SetActive(false);
            gunFire.SetActive(false);
            Debug.Log("Gun is not active");
        }
        Vector3 difference = Camera.main.ScreenToWorldPoint(Input.mousePosition) - transform.position;
        float rotZ = Mathf.Atan2(difference.y, difference.x) * Mathf.Rad2Deg;
        transform.rotation = Quaternion.Euler(0f, 0f, rotZ + offset);

        if (timeBtwnShots <= 0)
        {
            // If left mouse button is clicked, shoot

            if (Input.GetMouseButton(0) && projectile.activeSelf && gunFire.activeSelf)
            {
                Instantiate(gunFire, transform.position, Quaternion.identity);
                Instantiate(projectile, shotPoint.position, transform.rotation);
                timeBtwnShots = startTimeBtwnShots;
                
            }
        }
        else {
            timeBtwnShots -= Time.deltaTime;
        }
        
    }

    void DestroyProjectile()
    {
        Destroy(gameObject);
    }
}

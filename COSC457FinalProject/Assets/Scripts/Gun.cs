using System.Collections;
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
        if (player.GetComponent<PlayerInventory>().IsInInventory("Gun") == true)
        {
            projectile.SetActive(true);
            gunFire.SetActive(true);
        }
        Vector3 difference = Camera.main.ScreenToWorldPoint(Input.mousePosition) - transform.position;
        float rotZ = Mathf.Atan2(difference.y, difference.x) * Mathf.Rad2Deg;
        transform.rotation = Quaternion.Euler(0f, 0f, rotZ + offset);

        if (timeBtwnShots <= 0)
        {


            if (Input.GetMouseButton(0))
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

    void checkForGun()
    {
        // Check if gun is equipped.
    }
}

using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ZombieSpawner : MonoBehaviour
{
    public GameObject zombie;
    float ranY;
    Vector2 whereToSpawn;
    public float spawnRate = 2f;
    float nextSpawn = 0;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        if (Time.time > nextSpawn)
        {
            nextSpawn = Time.time + spawnRate;
            ranY = Random.Range(-400f, 400f);
            whereToSpawn = new Vector2(transform.position.x, ranY);
            Instantiate(zombie, whereToSpawn, Quaternion.identity);
        }
    }
}

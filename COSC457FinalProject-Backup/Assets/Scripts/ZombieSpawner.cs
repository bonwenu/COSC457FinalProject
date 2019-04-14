using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ZombieSpawner : MonoBehaviour
{
    public GameObject smallZombie;
    public GameObject mediumZombie;
    public GameObject largeZombie;
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
        System.Random r = new System.Random();
        int num = r.Next(3);
        if (Time.time > nextSpawn)
        {
            nextSpawn = Time.time + spawnRate;
            ranY = Random.Range(-400f, 400f);
            whereToSpawn = new Vector2(transform.position.x, ranY);
            if (num == 0)
            {
                Instantiate(smallZombie, whereToSpawn, Quaternion.identity);
            }
            if (num == 1)
            {
                Instantiate(mediumZombie, whereToSpawn, Quaternion.identity);
            }
            if (num == 2)
            {
                Instantiate(largeZombie, whereToSpawn, Quaternion.identity);
            }
        }
    }
}

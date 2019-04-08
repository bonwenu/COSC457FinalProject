using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class NewBehaviourScript : MonoBehaviour
{
    public float speed;
    public float lifetime;
    public float distance;
    public LayerMask whatIsSolid;
    public float damage;

    // Start is called before the first frame update
    void Start()
    {
        Invoke("DestroyProjectile", lifetime);
    }

    // Update is called once per frame
    void Update()
    {
        RaycastHit2D hitInfo = Physics2D.Raycast(transform.position, transform.up, distance, whatIsSolid);
        if(hitInfo.collider != null)
        {
            if(hitInfo.collider.CompareTag("Zombie"))
            {
                Debug.Log("Enemy must take damage!");
                hitInfo.collider.GetComponent<EnemyCombat>().TakeDamage(damage);
            }
            DestroyProjectile();
        }
        transform.Translate(transform.up * speed * Time.deltaTime);
    }
    void DestroyProjectile()
    {
        Destroy(gameObject);
    }
}

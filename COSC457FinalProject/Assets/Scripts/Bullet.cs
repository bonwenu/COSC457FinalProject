using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Bullet : MonoBehaviour
{
    public float speed;
    public float lifetime;
    public float distance;
    public LayerMask whatIsSolid;
    public float damage;

    // Start is called before the first frame update
    void Start()
    {
        //damage = damage / 10;
        Invoke("DestroyProjectile", lifetime);
    }

    // Update is called once per frame
    void Update()
    {
        RaycastHit2D hitInfo = Physics2D.Raycast(transform.position, transform.up, distance, whatIsSolid);
        if (hitInfo.collider != null)
        {
            if (hitInfo.collider.CompareTag("zombie"))
            {
                Debug.Log("Enemy must take damage!");
                hitInfo.collider.GetComponent<EnemyCombat>().TakeDamage(damage);
            }
            DestroyProjectile();
        }
        transform.Translate(Vector2.up * speed * Time.deltaTime);
    }
    void DestroyProjectile()
    {
        Destroy(gameObject);
    }
}

using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyBulletController : MonoBehaviour
{
    [SerializeField] private float bulletSpeed;
    [SerializeField] private Rigidbody2D rb;
    [SerializeField] private int damage;
    [SerializeField] private GameObject particles;
    private GameObject deathBounds;


    private void Start()
    {
        deathBounds = GameObject.Find("Collider");
    }
    private void FixedUpdate()
    {
        rb.velocity = transform.up * bulletSpeed;
        if (deathBounds.transform.position.y > this.transform.position.y)
        {
            Destroy(this.gameObject);
        }
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.tag == "Player")
        { 
            PlayerController player = collision.GetComponent<PlayerController>();
            player.DecrementHealth(damage);
            
            Instantiate(particles, this.transform.position, Quaternion.identity);
            Destroy(this.gameObject);
        }
    }
}

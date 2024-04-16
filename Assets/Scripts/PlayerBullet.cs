using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerBullet : MonoBehaviour
{
    [SerializeField] private float bulletSpeed;
    [SerializeField] private Rigidbody2D rb;
    [SerializeField] private int damage;

    private void FixedUpdate()
    {
        rb.velocity = transform.up * bulletSpeed;
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.tag == "Enemy")
        {
            Enemy enemy = collision.GetComponent<Enemy>();
            enemy.DecrementHealth(damage);
            Destroy(this.gameObject);
        }
    }
}

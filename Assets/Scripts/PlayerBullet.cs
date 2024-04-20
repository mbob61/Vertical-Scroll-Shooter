using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerBullet : MonoBehaviour
{
    [SerializeField] private float bulletSpeed;
    [SerializeField] private Rigidbody2D rb;
    [SerializeField] private int damage;
    [SerializeField] private GameObject particles;
    private GameObject topCollider;

    private void Start()
    {
        topCollider = GameObject.Find("TopCollider");
    }

    private void FixedUpdate()
    {
        rb.velocity = transform.up * bulletSpeed;
        if(topCollider.transform.position.y < this.transform.position.y)
        {
            Destroy(this.gameObject);
        }
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.tag == "Enemy")
        {
            Enemy enemy = collision.GetComponent<Enemy>();
            enemy.DecrementHealth(damage);
            SoundManager.PlaySound(SoundManager.Sound.hit);
            Instantiate(particles, this.transform.position, Quaternion.identity);
            Destroy(this.gameObject);
        }
    }
}

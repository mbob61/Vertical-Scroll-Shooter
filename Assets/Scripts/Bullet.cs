using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Bullet : MonoBehaviour
{
    [SerializeField] private float bulletSpeed;
    [SerializeField] private Rigidbody2D rb;

    private void FixedUpdate()
    {
        rb.velocity = transform.up * bulletSpeed;
    }
}

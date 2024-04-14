using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerController : MonoBehaviour
{
    private Vector2 movement;
    [SerializeField] private Rigidbody2D rb;
    [SerializeField] private float moveSpeed;
    [SerializeField] private GameObject bullet;
    // Start is called before the first frame update


    private void OnEnable()
    {
        
    }


    private void OnDisable()
    {
        
    }


    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {
        Move();
    }


    void Move()
    {
        movement.x = Input.GetAxisRaw("Horizontal");
        movement.y = Input.GetAxisRaw("Vertical");

        movement.Normalize();

        rb.velocity = movement * moveSpeed;
        
    }
}

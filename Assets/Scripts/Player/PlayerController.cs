using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerController : MonoBehaviour
{
    [SerializeField] private PlayerMovementController playerMovementController;
    [SerializeField] private int maxHealth;
    [SerializeField] GameObject particleEffect;
    private int currentHealth;

    private void Awake()
    {
        currentHealth = maxHealth;
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.tag == "WaterLayer")
        {
            playerMovementController.SetWaterMovementMultiplier();
        }
    }

    private void OnTriggerStay2D(Collider2D collision)
    {
        OnTriggerEnter2D(collision);
    }

    private void OnTriggerExit2D(Collider2D collision)
    {
        if (collision.tag == "WaterLayer")
        {
            playerMovementController.SetDefaultMovementMultiplier();
        }
    }

    public void DecrementHealth(int healthToLose)
    {
        currentHealth -= healthToLose;
    }

    private void Update()
    {
        if (currentHealth <= 0)
        {
            Death();
        }
    }

    private void Death()
    {
        Instantiate(particleEffect, this.transform.position, Quaternion.identity);
        Destroy(this.gameObject);
    }
}

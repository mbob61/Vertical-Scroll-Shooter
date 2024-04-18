using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Enemy : MonoBehaviour
{
    [SerializeField] private int maxHealth = 5;
    [SerializeField] GameObject particleEffect;
    private int currentHealth;

    private void Awake()
    {
        
        currentHealth = maxHealth;
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

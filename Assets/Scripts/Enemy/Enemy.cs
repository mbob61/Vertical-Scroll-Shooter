using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Enemy : MonoBehaviour
{
    [SerializeField] private int maxHealth = 5;
    [SerializeField] private GameObject particleEffect;
    private GameObject deathBounds;
    private int currentHealth;

    private void Awake()
    {
        deathBounds = GameObject.Find("Collider");    
        currentHealth = maxHealth;
    }

    private void FixedUpdate()
    {
        if(deathBounds.transform.position.y > this.transform.position.y)
        {
            Destroy(this.gameObject);
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
        SoundManager.PlaySound(SoundManager.Sound.explosion);
        Instantiate(particleEffect, this.transform.position, Quaternion.identity);
        Destroy(this.gameObject);
    }
}

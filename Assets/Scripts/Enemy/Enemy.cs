using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Enemy : MonoBehaviour
{
    [SerializeField] private int maxHealth = 5;
    [SerializeField] private GameObject particleEffect;
    [SerializeField] private GameObject smokeParticles;
    private GameObject localSmokeParticles;
    private GameObject deathBounds;
    private int currentHealth;
    private bool smoke = false;
    DamageFlash damageFlash;

    private void Awake()
    {
        deathBounds = GameObject.Find("Collider");    
        currentHealth = maxHealth;
        damageFlash = GetComponent<DamageFlash>();
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
        damageFlash.CallDamageFlash();
        currentHealth -= healthToLose;
    }

    private void Update()
    {
        if (currentHealth <= 0)
        {
            Death();
        }
        if(currentHealth < maxHealth * 0.5f && !smoke)
        {
            smoke = true;
            localSmokeParticles = Instantiate(smokeParticles, this.transform.position, Quaternion.identity);
        }



    }

    private void Death()
    {
        SoundManager.PlaySound(SoundManager.Sound.explosion);
        Instantiate(particleEffect, this.transform.position, Quaternion.identity);
        Destroy(this.gameObject);
        Destroy(localSmokeParticles);
    }
}

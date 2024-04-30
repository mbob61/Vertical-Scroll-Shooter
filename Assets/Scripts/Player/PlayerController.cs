using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerController : MonoBehaviour
{
    [SerializeField] private PlayerMovementController playerMovementController;
    [SerializeField] private int maxHealth;
    [SerializeField] GameObject particleEffect;

    [SerializeField] private GameObject heartOne;
    [SerializeField] private GameObject heartTwo;
    [SerializeField] private GameObject heartThree;
    [SerializeField] private GameObject heartFour;
    [SerializeField] private GameObject heartFive;

    [SerializeField] private GameObject splashParticlesWater;
    [SerializeField] private GameObject splashParicleLava;

    private GameObject tryAgain;

    private List<GameObject> hearts = new List<GameObject>();
    private int currentHealth;

    private bool inWater = false;
    private bool inLava = false;
    [SerializeField] private float lavaResistance = 1;
    private float lavaCount = 1;
    [SerializeField] private GameObject turret;
    [SerializeField] private GameObject smokeParticles;
    private GameObject localSmokeParticles;


    private DamageFlash damageFlash;

    private void Awake()
    {
        localSmokeParticles = Instantiate(smokeParticles, this.transform.position, Quaternion.identity);
        localSmokeParticles.transform.parent = this.gameObject.transform;
        localSmokeParticles.SetActive(false);

        damageFlash = GetComponent<DamageFlash>();
        tryAgain = GameObject.Find("TryAgain");
        tryAgain.SetActive(false);
        heartOne = GameObject.Find("HeartContainer1");
        heartTwo = GameObject.Find("HeartContainer2");
        heartThree = GameObject.Find("HeartContainer3");
        heartFour = GameObject.Find("HeartContainer4");
        heartFive = GameObject.Find("HeartContainer5");
        hearts.Add(heartOne);
        hearts.Add(heartTwo);
        hearts.Add(heartThree);
        hearts.Add(heartFour);
        hearts.Add(heartFive);

        currentHealth = maxHealth;

        splashParicleLava.SetActive(false);
        splashParticlesWater.SetActive(false);
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.tag == "WaterLayer")
        {
            inWater = true;
            playerMovementController.SetWaterMovementMultiplier();
            //splashParticlesWater.SetActive(true);
        }

        if(collision.tag == "LavaLayer")
        {
            inLava = true;
            this.GetComponent<SpriteRenderer>().material.SetColor("_SpriteColour", Color.red);
            turret.GetComponent<SpriteRenderer>().material.SetColor("_SpriteColour", Color.red);

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
            inWater = false;
            splashParticlesWater.SetActive(false);
            playerMovementController.SetDefaultMovementMultiplier();
        }
        if( collision.tag == "LavaLayer")
        {
            inLava = false;
            this.GetComponent<SpriteRenderer>().material.SetColor("_SpriteColour", Color.white);
            turret.GetComponent<SpriteRenderer>().material.SetColor("_SpriteColour", Color.white);
        }
    }

    public void DecrementHealth(int healthToLose)
    {
        currentHealth -= healthToLose;
        if (currentHealth > -1)
        {
            damageFlash.CallDamageFlash();
            SoundManager.PlaySound(SoundManager.Sound.hit);
            hearts[currentHealth].SetActive(false);
        }

        if (currentHealth < maxHealth * 0.5f)
        {
            localSmokeParticles.SetActive(true);
        }
    }

    public void IncrementHealth(int healthToGain)
    {
        if (currentHealth + healthToGain <= maxHealth)
        {
            
            hearts[currentHealth].SetActive(true);
            currentHealth += healthToGain;
        }
        if (currentHealth > maxHealth * 0.5f)
        {
            localSmokeParticles.SetActive(false);
        }
    }

    private void Update()
    {
        if (currentHealth <= 0)
        {
            Death();
        }

        if (inLava)
        {

            if (lavaCount > 0)
            {
                lavaCount -= Time.deltaTime;
            }
            else
            {
                DecrementHealth(1);
                lavaCount = lavaResistance;
            }

            if (this.GetComponent<Rigidbody2D>().velocity.magnitude > 0.01f)
            {
                splashParicleLava.SetActive(true);
            }
            else
            {
                splashParicleLava.SetActive(false);
            }
        }
        else
        {
            splashParicleLava.SetActive(false);
            lavaCount = lavaResistance;
        }

        if (this.GetComponent<Rigidbody2D>().velocity.magnitude > 0.01f && inWater)
        {
            splashParticlesWater.SetActive(true);
        }
        else
        {
            splashParticlesWater.SetActive(false);
        }

        
    }

    private void Death()
    {
        tryAgain.SetActive(true);
        SoundManager.PlaySound(SoundManager.Sound.explosion);
        Instantiate(particleEffect, this.transform.position, Quaternion.identity);
        Destroy(this.gameObject);
    }
}

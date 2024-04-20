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

    private List<GameObject> hearts = new List<GameObject>();
    private int currentHealth;

    private bool inLava = false;
    [SerializeField] private float lavaResistance = 1;
    private float lavaCount = 1;
    [SerializeField] private GameObject turret;

    private void Awake()
    {
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
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.tag == "WaterLayer")
        {
            playerMovementController.SetWaterMovementMultiplier();
        }

        if(collision.tag == "LavaLayer")
        {
            inLava = true;
            this.GetComponent<SpriteRenderer>().color = Color.red;
            turret.GetComponent<SpriteRenderer>().color = Color.red;

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
        if( collision.tag == "LavaLayer")
        {
            inLava = false;
            this.GetComponent<SpriteRenderer>().color = Color.white;
            turret.GetComponent<SpriteRenderer>().color = Color.white;
        }
    }

    public void DecrementHealth(int healthToLose)
    {
        currentHealth -= healthToLose;
        if (currentHealth > -1)
        {
            hearts[currentHealth].SetActive(false);
        }
    }

    public void IncrementHealth(int healthToGain)
    {
        if (currentHealth + healthToGain <= maxHealth)
        {
            currentHealth += healthToGain;
            hearts[currentHealth].SetActive(true);
        }
    }

    private void Update()
    {
        if (currentHealth <= 0)
        {
            Death();
        }

        if(inLava)
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
        }
        else
        {
            lavaCount = lavaResistance;
        }
    }

    private void Death()
    {
        SoundManager.PlaySound(SoundManager.Sound.explosion);
        Instantiate(particleEffect, this.transform.position, Quaternion.identity);
        Destroy(this.gameObject);
    }
}

using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class StationaryEnemyController : MonoBehaviour
{
    [SerializeField] private int maxHealth = 5;
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
            Destroy(this.gameObject);
        }
    }
}

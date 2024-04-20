using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyTurretController : MonoBehaviour
{
    [SerializeField] private EnemyTurretDetectionRadius detectionRadius;
    [SerializeField] private float shotTimer = 1.0f;
    [SerializeField] private GameObject enemyBulletPrefab;
    [SerializeField] private List<Transform> firePoints;

    private float currentShotTimer;

    private void Awake()
    {
        currentShotTimer = shotTimer;
    }

    // Update is called once per frame
    void Update()
    {
       if (detectionRadius.GetTarget())
       {
            if (currentShotTimer > 0)
            {
                if (currentShotTimer - Time.deltaTime > 0)
                {
                    currentShotTimer -= Time.deltaTime;
                } else
                {
                    foreach (Transform firePoint in firePoints)
                    {
                        SoundManager.PlaySound(SoundManager.Sound.enemyFire);
                        Instantiate(enemyBulletPrefab, firePoint.position, transform.rotation);
                    }
                    currentShotTimer = shotTimer * GameAssets.enemyAttackSpeed;
                }
            }
       }
       else
       {
            currentShotTimer = shotTimer * GameAssets.enemyAttackSpeed;
       }    
    }
}

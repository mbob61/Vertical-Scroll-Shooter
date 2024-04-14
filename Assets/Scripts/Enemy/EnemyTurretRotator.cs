using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyTurretRotator : MonoBehaviour
{
    [SerializeField] private EnemyTurretDetectionRadius detectionRadius;

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        if (detectionRadius.GetTarget())
        {
            Vector2 playerPosition = detectionRadius.GetTarget().transform.position;
            Vector2 turretPosition = transform.position;

            // Track the position of the player
            Vector2 vectorToTarget = playerPosition - turretPosition;
            float angle = Mathf.Atan2(vectorToTarget.y, vectorToTarget.x) * Mathf.Rad2Deg - 90;
            Quaternion q = Quaternion.AngleAxis(angle, Vector3.forward);
            transform.rotation = Quaternion.Slerp(transform.rotation, q, Time.deltaTime * 10.0f);
        }
    }
}

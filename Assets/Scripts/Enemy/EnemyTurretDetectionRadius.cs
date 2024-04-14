using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyTurretDetectionRadius : MonoBehaviour
{
    private GameObject target;


    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.tag == "Player")
        {
            if (!target)
            {
                target = collision.gameObject;
            }
        }
    }

    private void OnTriggerStay2D(Collider2D collision)
    {
        OnTriggerEnter2D(collision);
    }

    private void OnTriggerExit2D(Collider2D collision)
    {
        if(collision.tag == "Player")
        {
            if (target)
            {
                target = null;
            }
        }
    }

    private void Update()
    {
        if (target)
        {
            if (!target.activeSelf)
            {
                target = null;
            }
        }

        print(target);
    }

    public GameObject GetTarget()
    {
        return target ? target : null;
    }
}

using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerController : MonoBehaviour
{

    [SerializeField] private PlayerMovementController playerMovementController;

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

}

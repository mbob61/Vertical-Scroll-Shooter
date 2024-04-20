using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;

public class PlayerShootingController : MonoBehaviour
{
    [SerializeField] private GameObject bulletPrefab;
    [SerializeField] private Transform firePoint;
    [SerializeField] private Transform turret;
    private GameObject choicesObject;


    private void Start()
    {
        choicesObject = GameObject.Find("Choice");
    }
    public void OnShoot(InputAction.CallbackContext context)
    {
        if (context.performed && !choicesObject.activeSelf)
        {
            SoundManager.PlaySound(SoundManager.Sound.playerFire);
            Instantiate(bulletPrefab, firePoint.position, turret.rotation);
        }
    }
}

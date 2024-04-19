using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;

public class PlayerShootingController : MonoBehaviour
{
    [SerializeField] private GameObject bulletPrefab;
    [SerializeField] private Transform firePoint;
    [SerializeField] private Transform turret;

    public void OnShoot(InputAction.CallbackContext context)
    {
        if (context.performed)
        {
            SoundManager.PlaySound(SoundManager.Sound.playerFire);
            Instantiate(bulletPrefab, firePoint.position, turret.rotation);
        }
    }
}

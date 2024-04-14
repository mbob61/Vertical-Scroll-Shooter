using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerTurretRotator : MonoBehaviour
{
    [SerializeField] private Rigidbody2D rb;
    [SerializeField] private bool allow8WayRotation = true;
    private float angle;

    private void FixedUpdate()
    {
        if (allow8WayRotation && rb.velocity != Vector2.zero)
        {
            Vector2 v = rb.velocity;
            angle = (Mathf.Atan2(v.y, v.x) * Mathf.Rad2Deg) - 90;
            transform.rotation = Quaternion.AngleAxis(angle, Vector3.forward);
        }
    }
}
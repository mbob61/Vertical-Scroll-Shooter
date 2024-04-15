using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;

public class PlayerMovementController : MonoBehaviour
{
    [SerializeField] private Rigidbody2D rb;
    [SerializeField] private float moveSpeed = 3.0f;
    private float horizontal, vertical;
    private Vector3 movementVector;

    [SerializeField] private float defaultMovementMultiplier = 1.0f;
    [SerializeField] private float waterMovementMultiplier = 0.5f;

    [SerializeField] private Animator animator;

    private float currentMovementMultiplier;

    private void Awake()
    {
        currentMovementMultiplier = defaultMovementMultiplier;
    }

    public void OnHorizontal(InputAction.CallbackContext context)
    {
        horizontal = context.ReadValue<float>();
    }

    public void OnVertical(InputAction.CallbackContext context)
    {
        vertical = context.ReadValue<float>();
    }

    private void FixedUpdate()
    {
        movementVector = new Vector3(horizontal, vertical, 0.0f);
        movementVector.Normalize();

        rb.velocity = movementVector * moveSpeed * currentMovementMultiplier;



    }

    private void Update()
    {
        animator.SetFloat("PlayerVelocity", rb.velocity.magnitude);

    }

    public void SetDefaultMovementMultiplier()
    {
        if (currentMovementMultiplier != defaultMovementMultiplier) currentMovementMultiplier = defaultMovementMultiplier;
    }

    public void SetWaterMovementMultiplier()
    {
        if (currentMovementMultiplier != waterMovementMultiplier) currentMovementMultiplier = waterMovementMultiplier;
    }
}

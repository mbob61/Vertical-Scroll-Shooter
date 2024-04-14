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

        rb.velocity = movementVector * moveSpeed;
    }


    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}

using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SmoothCameraFollow : MonoBehaviour
{
    private Transform target;
    [SerializeField] private Vector3 offset;
    [SerializeField] private float damping;
    private Vector3 velocity = Vector3.zero;

    private void FixedUpdate()
    {
        try
        {
            target = GameObject.Find("Player(Clone)").GetComponent<Transform>();

            if (target.position.y + offset.y > transform.position.y)
            {
                Vector3 movePosition = new Vector3(0, target.position.y) + offset;
                transform.position = Vector3.SmoothDamp(transform.position, movePosition, ref velocity, damping);
            }
        } catch (Exception ex)
        {
            print(ex);
        }
        
    }
}

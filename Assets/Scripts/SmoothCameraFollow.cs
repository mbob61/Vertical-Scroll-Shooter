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

    // Start is called before the first frame update
    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {
        
    }

    private void FixedUpdate()
    {
        try
        {
            if (target.position.y > transform.position.y)
            {
                Vector3 movePosition = new Vector3(0,target.position.y) + offset;
                transform.position = Vector3.SmoothDamp(transform.position, movePosition, ref velocity, damping);
            }
        }
        catch(Exception ex)
        {
            target = GameObject.Find("Player(Clone)").GetComponent<Transform>();
        }
    }
}

using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DetectBounds : MonoBehaviour
{
    private Vector3 bottomLeftWorld;
    // Start is called before the first frame update
    void Start()
    {
        bottomLeftWorld = Camera.main.ViewportToWorldPoint(new Vector3(0, 0, Camera.main.nearClipPlane));
    }

    // Update is called once per frame
    void Update()
    {
        bottomLeftWorld = Camera.main.ViewportToWorldPoint(new Vector3(0, 0, Camera.main.nearClipPlane));

        if(this.transform.position.y < (bottomLeftWorld.y - 1))
        {
            Destroy(this.gameObject);

        }
    }
}

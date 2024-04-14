using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameManager : MonoBehaviour
{
    [SerializeField] private GameObject leftWallPiece;
    [SerializeField] private GameObject rightWallPiece;
    [SerializeField] private GameObject backroundWallPiece;
    [SerializeField] private GameObject floorPiece;
    [SerializeField] private GameObject player;
    private GameObject playerRef;

    private Vector3 playerLastPosition;
    private Vector3 lastPosition;
    private Vector3 bottomLeftWorld;
    private Vector3 topRightWorld;
    // Start is called before the first frame update
    void Start()
    {
        bottomLeftWorld = Camera.main.ViewportToWorldPoint(new Vector3(0, 0, Camera.main.nearClipPlane)); 
        topRightWorld = Camera.main.ViewportToWorldPoint(new Vector3(1, 1, Camera.main.nearClipPlane));

        playerRef = Instantiate(player, new Vector3(0, 0), Quaternion.identity);
        playerLastPosition = new Vector3(0, 0);

        for (int i = 0; i <= topRightWorld.y * 2 + 1; i++)
        {
            Instantiate(leftWallPiece, new Vector3(bottomLeftWorld.x / 2, bottomLeftWorld.y + i), Quaternion.identity);
            Instantiate(rightWallPiece, new Vector3(topRightWorld.x / 2, bottomLeftWorld.y + i), Quaternion.identity);

            Instantiate(floorPiece, new Vector3(bottomLeftWorld.x / 2 + 1, bottomLeftWorld.y + i), Quaternion.identity);
            Instantiate(floorPiece, new Vector3(bottomLeftWorld.x / 2 + 2, bottomLeftWorld.y + i), Quaternion.identity);
            Instantiate(floorPiece, new Vector3(bottomLeftWorld.x / 2 + 3, bottomLeftWorld.y + i), Quaternion.identity);
            Instantiate(floorPiece, new Vector3(bottomLeftWorld.x / 2 + 4, bottomLeftWorld.y + i), Quaternion.identity);

            Instantiate(floorPiece, new Vector3(bottomLeftWorld.x / 2 + 5, bottomLeftWorld.y + i), Quaternion.identity);
            Instantiate(floorPiece, new Vector3(bottomLeftWorld.x / 2 + 6, bottomLeftWorld.y + i), Quaternion.identity);
            Instantiate(floorPiece, new Vector3(bottomLeftWorld.x / 2 + 7, bottomLeftWorld.y + i), Quaternion.identity);
            Instantiate(floorPiece, new Vector3(bottomLeftWorld.x / 2 + 8, bottomLeftWorld.y + i), Quaternion.identity);

            Instantiate(backroundWallPiece, new Vector3(bottomLeftWorld.x / 2 - 1, bottomLeftWorld.y + i), Quaternion.identity);
            Instantiate(backroundWallPiece, new Vector3(bottomLeftWorld.x / 2 - 2, bottomLeftWorld.y + i), Quaternion.identity);
            Instantiate(backroundWallPiece, new Vector3(bottomLeftWorld.x / 2 - 3, bottomLeftWorld.y + i), Quaternion.identity);
            Instantiate(backroundWallPiece, new Vector3(bottomLeftWorld.x / 2 - 4, bottomLeftWorld.y + i), Quaternion.identity);
            Instantiate(backroundWallPiece, new Vector3(bottomLeftWorld.x / 2 - 5, bottomLeftWorld.y + i), Quaternion.identity);

            Instantiate(backroundWallPiece, new Vector3(topRightWorld.x / 2 + 1, bottomLeftWorld.y + i), Quaternion.identity);
            Instantiate(backroundWallPiece, new Vector3(topRightWorld.x / 2 + 2, bottomLeftWorld.y + i), Quaternion.identity);
            Instantiate(backroundWallPiece, new Vector3(topRightWorld.x / 2 + 3, bottomLeftWorld.y + i), Quaternion.identity);
            Instantiate(backroundWallPiece, new Vector3(topRightWorld.x / 2 + 4, bottomLeftWorld.y + i), Quaternion.identity);
            Instantiate(backroundWallPiece, new Vector3(topRightWorld.x / 2 + 5, bottomLeftWorld.y + i), Quaternion.identity);
            lastPosition.y = bottomLeftWorld.y + i + 1;
        }
    }

    // Update is called once per frame
    void Update()
    {
        if ((playerRef.transform.position.y - playerLastPosition.y) > 1)
        {
            CreateLayer();
        }
    }


    private void CreateLayer()
    {
        Instantiate(leftWallPiece, new Vector3(bottomLeftWorld.x / 2, lastPosition.y), Quaternion.identity);
        Instantiate(rightWallPiece, new Vector3(topRightWorld.x / 2, lastPosition.y), Quaternion.identity);

        Instantiate(floorPiece, new Vector3(bottomLeftWorld.x / 2 + 1, lastPosition.y), Quaternion.identity);
        Instantiate(floorPiece, new Vector3(bottomLeftWorld.x / 2 + 2, lastPosition.y), Quaternion.identity);
        Instantiate(floorPiece, new Vector3(bottomLeftWorld.x / 2 + 3, lastPosition.y), Quaternion.identity);
        Instantiate(floorPiece, new Vector3(bottomLeftWorld.x / 2 + 4, lastPosition.y), Quaternion.identity);

        Instantiate(floorPiece, new Vector3(bottomLeftWorld.x / 2 + 5, lastPosition.y), Quaternion.identity);
        Instantiate(floorPiece, new Vector3(bottomLeftWorld.x / 2 + 6, lastPosition.y), Quaternion.identity);
        Instantiate(floorPiece, new Vector3(bottomLeftWorld.x / 2 + 7, lastPosition.y), Quaternion.identity);
        Instantiate(floorPiece, new Vector3(bottomLeftWorld.x / 2 + 8, lastPosition.y), Quaternion.identity);

        Instantiate(backroundWallPiece, new Vector3(bottomLeftWorld.x / 2 - 1, lastPosition.y), Quaternion.identity);
        Instantiate(backroundWallPiece, new Vector3(bottomLeftWorld.x / 2 - 2, lastPosition.y), Quaternion.identity);
        Instantiate(backroundWallPiece, new Vector3(bottomLeftWorld.x / 2 - 3, lastPosition.y), Quaternion.identity);
        Instantiate(backroundWallPiece, new Vector3(bottomLeftWorld.x / 2 - 4, lastPosition.y), Quaternion.identity);
        Instantiate(backroundWallPiece, new Vector3(bottomLeftWorld.x / 2 - 5, lastPosition.y), Quaternion.identity);

        Instantiate(backroundWallPiece, new Vector3(topRightWorld.x / 2 + 1, lastPosition.y), Quaternion.identity);
        Instantiate(backroundWallPiece, new Vector3(topRightWorld.x / 2 + 2, lastPosition.y), Quaternion.identity);
        Instantiate(backroundWallPiece, new Vector3(topRightWorld.x / 2 + 3, lastPosition.y), Quaternion.identity);
        Instantiate(backroundWallPiece, new Vector3(topRightWorld.x / 2 + 4, lastPosition.y), Quaternion.identity);
        Instantiate(backroundWallPiece, new Vector3(topRightWorld.x / 2 + 5, lastPosition.y), Quaternion.identity);
        playerLastPosition.y += 1;
        lastPosition.y += 1;
    }
}

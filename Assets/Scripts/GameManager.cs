using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameManager : MonoBehaviour
{
    [SerializeField] private GameObject floorTileParent;
    [SerializeField] private GameObject backgroundTileParent;
    [SerializeField] private GameObject wallPiecesParent;

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

        //for (int i = 0; i <= topRightWorld.y * 2 + 1; i++)
        //{
        //    CreateWallTiles(i);
        //    createFloorTiles(i);
        //    createBackgroundTiles(i);

        //    lastPosition.y = bottomLeftWorld.y + i + 1;
        //}
    }

    private void CreateWallTiles(int i)
    {
        GameObject wallTile1 = Instantiate(leftWallPiece, new Vector3(bottomLeftWorld.x / 2, bottomLeftWorld.y + i), Quaternion.identity);
        GameObject wallTile2 = Instantiate(rightWallPiece, new Vector3(topRightWorld.x / 2, bottomLeftWorld.y + i), Quaternion.identity);

        wallTile1.transform.parent = wallPiecesParent.transform;
        wallTile2.transform.parent = wallPiecesParent.transform;

    }

    private void createFloorTiles(int i)
    {
        GameObject floor1 = Instantiate(floorPiece, new Vector3(bottomLeftWorld.x / 2 + 1, bottomLeftWorld.y + i), Quaternion.identity);
        GameObject floor2 = Instantiate(floorPiece, new Vector3(bottomLeftWorld.x / 2 + 2, bottomLeftWorld.y + i), Quaternion.identity);
        GameObject floor3 = Instantiate(floorPiece, new Vector3(bottomLeftWorld.x / 2 + 3, bottomLeftWorld.y + i), Quaternion.identity);
        GameObject floor4 = Instantiate(floorPiece, new Vector3(bottomLeftWorld.x / 2 + 4, bottomLeftWorld.y + i), Quaternion.identity);
        GameObject floor5 = Instantiate(floorPiece, new Vector3(bottomLeftWorld.x / 2 + 5, bottomLeftWorld.y + i), Quaternion.identity);
        GameObject floor6 = Instantiate(floorPiece, new Vector3(bottomLeftWorld.x / 2 + 6, bottomLeftWorld.y + i), Quaternion.identity);
        GameObject floor7 = Instantiate(floorPiece, new Vector3(bottomLeftWorld.x / 2 + 7, bottomLeftWorld.y + i), Quaternion.identity);
        GameObject floor8 = Instantiate(floorPiece, new Vector3(bottomLeftWorld.x / 2 + 8, bottomLeftWorld.y + i), Quaternion.identity);

        floor1.transform.parent = floorTileParent.transform;
        floor2.transform.parent = floorTileParent.transform;
        floor3.transform.parent = floorTileParent.transform;
        floor4.transform.parent = floorTileParent.transform;
        floor5.transform.parent = floorTileParent.transform;
        floor6.transform.parent = floorTileParent.transform;
        floor7.transform.parent = floorTileParent.transform;
        floor8.transform.parent = floorTileParent.transform;
    }

    private void createBackgroundTiles(int i)
    {
        GameObject backgroundPeice1 = Instantiate(backroundWallPiece, new Vector3(bottomLeftWorld.x / 2 - 1, bottomLeftWorld.y + i), Quaternion.identity);
        GameObject backgroundPeice2 = Instantiate(backroundWallPiece, new Vector3(bottomLeftWorld.x / 2 - 2, bottomLeftWorld.y + i), Quaternion.identity);
        GameObject backgroundPeice3 = Instantiate(backroundWallPiece, new Vector3(bottomLeftWorld.x / 2 - 3, bottomLeftWorld.y + i), Quaternion.identity);
        GameObject backgroundPeice4 = Instantiate(backroundWallPiece, new Vector3(bottomLeftWorld.x / 2 - 4, bottomLeftWorld.y + i), Quaternion.identity);
        GameObject backgroundPeice5 = Instantiate(backroundWallPiece, new Vector3(bottomLeftWorld.x / 2 - 5, bottomLeftWorld.y + i), Quaternion.identity);
        GameObject backgroundPeice6 = Instantiate(backroundWallPiece, new Vector3(topRightWorld.x / 2 + 1, bottomLeftWorld.y + i), Quaternion.identity);
        GameObject backgroundPeice7 = Instantiate(backroundWallPiece, new Vector3(topRightWorld.x / 2 + 2, bottomLeftWorld.y + i), Quaternion.identity);
        GameObject backgroundPeice8 = Instantiate(backroundWallPiece, new Vector3(topRightWorld.x / 2 + 3, bottomLeftWorld.y + i), Quaternion.identity);
        GameObject backgroundPeice9 = Instantiate(backroundWallPiece, new Vector3(topRightWorld.x / 2 + 4, bottomLeftWorld.y + i), Quaternion.identity);
        GameObject backgroundPeice10 = Instantiate(backroundWallPiece, new Vector3(topRightWorld.x / 2 + 5, bottomLeftWorld.y + i), Quaternion.identity);

        backgroundPeice1.transform.parent = backgroundTileParent.transform;
        backgroundPeice2.transform.parent = backgroundTileParent.transform;
        backgroundPeice3.transform.parent = backgroundTileParent.transform;
        backgroundPeice4.transform.parent = backgroundTileParent.transform;
        backgroundPeice5.transform.parent = backgroundTileParent.transform;
        backgroundPeice6.transform.parent = backgroundTileParent.transform;
        backgroundPeice7.transform.parent = backgroundTileParent.transform;
        backgroundPeice8.transform.parent = backgroundTileParent.transform;
        backgroundPeice9.transform.parent = backgroundTileParent.transform;
        backgroundPeice10.transform.parent = backgroundTileParent.transform;

    }

    // Update is called once per frame
    void Update()
    {
        //if ((playerRef.transform.position.y - playerLastPosition.y) > 1)
        //{
        //    CreateLayer();
        //}
    }


    private void CreateLayer()
    {
        GameObject wallTile1 = Instantiate(leftWallPiece, new Vector3(bottomLeftWorld.x / 2, lastPosition.y), Quaternion.identity);
        GameObject wallTile2 = Instantiate(rightWallPiece, new Vector3(topRightWorld.x / 2, lastPosition.y), Quaternion.identity);

        wallTile1.transform.parent = wallPiecesParent.transform;
        wallTile2.transform.parent = wallPiecesParent.transform;

        GameObject floor1 = Instantiate(floorPiece, new Vector3(bottomLeftWorld.x / 2 + 1, lastPosition.y), Quaternion.identity);
        GameObject floor2 = Instantiate(floorPiece, new Vector3(bottomLeftWorld.x / 2 + 2, lastPosition.y), Quaternion.identity);
        GameObject floor3 = Instantiate(floorPiece, new Vector3(bottomLeftWorld.x / 2 + 3, lastPosition.y), Quaternion.identity);
        GameObject floor4 = Instantiate(floorPiece, new Vector3(bottomLeftWorld.x / 2 + 4, lastPosition.y), Quaternion.identity);

        GameObject floor5 = Instantiate(floorPiece, new Vector3(bottomLeftWorld.x / 2 + 5, lastPosition.y), Quaternion.identity);
        GameObject floor6 = Instantiate(floorPiece, new Vector3(bottomLeftWorld.x / 2 + 6, lastPosition.y), Quaternion.identity);
        GameObject floor7 = Instantiate(floorPiece, new Vector3(bottomLeftWorld.x / 2 + 7, lastPosition.y), Quaternion.identity);
        GameObject floor8 = Instantiate(floorPiece, new Vector3(bottomLeftWorld.x / 2 + 8, lastPosition.y), Quaternion.identity);

        floor1.transform.parent = floorTileParent.transform;
        floor2.transform.parent = floorTileParent.transform;
        floor3.transform.parent = floorTileParent.transform;
        floor4.transform.parent = floorTileParent.transform;
        floor5.transform.parent = floorTileParent.transform;
        floor6.transform.parent = floorTileParent.transform;
        floor7.transform.parent = floorTileParent.transform;
        floor8.transform.parent = floorTileParent.transform;

        GameObject backgroundTile1 = Instantiate(backroundWallPiece, new Vector3(bottomLeftWorld.x / 2 - 1, lastPosition.y), Quaternion.identity);
        GameObject backgroundTile2 = Instantiate(backroundWallPiece, new Vector3(bottomLeftWorld.x / 2 - 2, lastPosition.y), Quaternion.identity);
        GameObject backgroundTile3 = Instantiate(backroundWallPiece, new Vector3(bottomLeftWorld.x / 2 - 3, lastPosition.y), Quaternion.identity);
        GameObject backgroundTile4 = Instantiate(backroundWallPiece, new Vector3(bottomLeftWorld.x / 2 - 4, lastPosition.y), Quaternion.identity);
        GameObject backgroundTile5 = Instantiate(backroundWallPiece, new Vector3(bottomLeftWorld.x / 2 - 5, lastPosition.y), Quaternion.identity);

        GameObject backgroundTile6 = Instantiate(backroundWallPiece, new Vector3(topRightWorld.x / 2 + 1, lastPosition.y), Quaternion.identity);
        GameObject backgroundTile7 = Instantiate(backroundWallPiece, new Vector3(topRightWorld.x / 2 + 2, lastPosition.y), Quaternion.identity);
        GameObject backgroundTile8 = Instantiate(backroundWallPiece, new Vector3(topRightWorld.x / 2 + 3, lastPosition.y), Quaternion.identity);
        GameObject backgroundTile9 = Instantiate(backroundWallPiece, new Vector3(topRightWorld.x / 2 + 4, lastPosition.y), Quaternion.identity);
        GameObject backgroundTile10 = Instantiate(backroundWallPiece, new Vector3(topRightWorld.x / 2 + 5, lastPosition.y), Quaternion.identity);

        backgroundTile1.transform.parent = backgroundTileParent.transform;
        backgroundTile2.transform.parent = backgroundTileParent.transform;
        backgroundTile3.transform.parent = backgroundTileParent.transform;
        backgroundTile4.transform.parent = backgroundTileParent.transform;
        backgroundTile5.transform.parent = backgroundTileParent.transform;
        backgroundTile6.transform.parent = backgroundTileParent.transform;
        backgroundTile7.transform.parent = backgroundTileParent.transform;
        backgroundTile8.transform.parent = backgroundTileParent.transform;
        backgroundTile9.transform.parent = backgroundTileParent.transform;
        backgroundTile10.transform.parent = backgroundTileParent.transform;

        playerLastPosition.y += 1;
        lastPosition.y += 1;
    }
}

using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using  TMPro;
using UnityEngine.UI;

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

    //UI references
    [SerializeField] GameObject choiceObject;
    [SerializeField] private TMP_Text choiceOne;
    [SerializeField] private TMP_Text choiceTwo;
    [SerializeField] private Button buttonOne;
    [SerializeField] private Button buttonTwo;

    [SerializeField] private GameObject water;
    [SerializeField] private GameObject lava;

    [SerializeField] private GameObject healthPickups;
    [SerializeField] private GameObject mines;
    [SerializeField] private GameObject trees;
    [SerializeField] private GameObject clouds;

    [SerializeField] private GameObject firstCheckpoint;
    [SerializeField] private GameObject secondCheckpoint;


    //Sprites for cards
    [SerializeField] private Sprite lavaCardSprite;
    [SerializeField] private Sprite waterCardSprite;
    [SerializeField] private Sprite cloudCardSprite;
    [SerializeField] private Sprite tressCardSprite;
    [SerializeField] private Sprite enemyAttackSpeedUpCardSprite;
    [SerializeField] private Sprite enemyAttackSpeedDownSprite;
    [SerializeField] private Sprite mineCardSprite;
    [SerializeField] private Sprite healthCardSprite;

    private Vector3 playerLastPosition;
    private Vector3 lastPosition;
    private Vector3 bottomLeftWorld;
    private Vector3 topRightWorld;
    // Start is called before the first frame update


    private List<Choice> choices = new List<Choice>();
    private List<Choice> chosenChoices = new List<Choice>();
    private List<string> selected = new List<string>();
    Choice first;
    Choice second;
    Choice third;
    Choice fourth;
    Choice fifth;
    Choice sixth;



    private GameObject goal;
    private GameObject endGameUI;
    struct Choice
    {
        public string question1;
        public UnityEngine.Events.UnityAction buttonEvent1;
        public string question2;
        public UnityEngine.Events.UnityAction buttonEvent2;
        public Sprite sprite1;
        public Sprite sprite2;

        public Choice(string question1, UnityEngine.Events.UnityAction buttonEvent1, string question2, UnityEngine.Events.UnityAction buttonEvent2, Sprite sprite1, Sprite sprite2)
        {
            this.question1 = question1;
            this.buttonEvent1 = buttonEvent1;
            this.question2 = question2;
            this.buttonEvent2 = buttonEvent2;
            this.sprite1 = sprite1;
            this.sprite2 = sprite2;
        }

    }
    void Start()
    {
        goal = GameObject.Find("Goal");
        endGameUI = GameObject.Find("EndGameUI");
        endGameUI.SetActive(false);

        clouds.SetActive(false);
        trees.SetActive(false);
        SoundManager.PlaySound(SoundManager.Sound.music, true);

        bottomLeftWorld = Camera.main.ViewportToWorldPoint(new Vector3(0, 0, Camera.main.nearClipPlane)); 
        topRightWorld = Camera.main.ViewportToWorldPoint(new Vector3(1, 1, Camera.main.nearClipPlane));

        playerRef = Instantiate(player, new Vector3(0, 0), Quaternion.identity);
        playerLastPosition = new Vector3(0, 0);

        mines.SetActive(false);
        healthPickups.SetActive(false);

        CreateChoices();
        choiceObject.SetActive(false);

        water.SetActive(false);
        lava.SetActive(false);

        PresentChoice();

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
        if (firstCheckpoint.activeSelf && playerRef != null)
        {
            if (playerRef.transform.position.y > firstCheckpoint.transform.position.y)
            {
                PresentChoice();
                firstCheckpoint.SetActive(false);
            }
        }
        if(secondCheckpoint.activeSelf && playerRef != null)
        {
            if (playerRef.transform.position.y > secondCheckpoint.transform.position.y)
            {
                PresentChoice();
                secondCheckpoint.SetActive(false);
            }
        }
        if(goal.activeSelf && playerRef != null)
        {
            if (playerRef.transform.position.y > goal.transform.position.y)
            {
                EndGame();
            }
        }
        
    }

    private void EndGame()
    {
        endGameUI.SetActive(true);
        Destroy(playerRef);
        
        // Delay(1);
        //Time.timeScale = 0;
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


    private void PresentChoice()
    {
        StartCoroutine(Delay(0.5f));
        int random = Random.Range(0, choices.Count);

        choiceOne.text = choices[random].question1;
        choiceTwo.text = choices[random].question2;
        buttonOne.onClick.RemoveAllListeners();
        buttonOne.onClick.AddListener(choices[random].buttonEvent1);
        Sprite tempSprite1 = choices[random].sprite1;
        buttonOne.GetComponent<Image>().sprite = tempSprite1;
        buttonTwo.onClick.RemoveAllListeners();
        buttonTwo.onClick.AddListener(choices[random].buttonEvent2);
        Sprite tempSprite2 = choices[random].sprite2;
        buttonTwo.GetComponent<Image>().sprite = tempSprite2;
        choiceObject.SetActive(true);
        chosenChoices.Add(choices[random]);
        choices.RemoveAt(random);
    }

    IEnumerator Delay(float delay)
    {
        yield return new WaitForSeconds(delay);
        if (choiceObject.activeSelf || endGameUI.activeSelf)
        {
            Time.timeScale = 0f;
        }
    }
    private void CreateChoices()
    {
        StartCoroutine(Delay(1));
        
        //first = new Choice("speed things\nup", SpeedUp, "Slow things\ndown", SlowDown, "none");
        second = new Choice("Faster", BulletsGoFast, "Slower", BulletsGoSlow, enemyAttackSpeedUpCardSprite, enemyAttackSpeedDownSprite);
        third = new Choice("Water", TurnOffLava, "Lava", TurnOffWater, waterCardSprite, lavaCardSprite);
        fourth = new Choice("Mines", ActivateMines, "Health", ActivateHealthPickups, mineCardSprite, healthCardSprite);
        fifth = new Choice("Trees", Trees, "Clouds", Clouds, tressCardSprite, cloudCardSprite);

        //choices.Add(first);
        choices.Add(second);
        choices.Add(third);
        choices.Add(fourth);
        choices.Add(fifth);
    }


    private void SpeedUp()
    {
        selected.Add("SpeedUp");
        Time.timeScale = 2f;
        choiceObject.SetActive(false);
    }
    private void SlowDown()
    {
        selected.Add("SlowDown");
        Time.timeScale = 0.5f;
        choiceObject.SetActive(false);
    }
    private void BulletsGoSlow()
    {
        GameAssets.enemyAttackSpeed = 1.2f;
        selected.Add("BulletsSlow");
        Time.timeScale = 1;
        choiceObject.SetActive(false);
    }
    private void BulletsGoFast()
    {
        GameAssets.enemyAttackSpeed = 0.5f;
        selected.Add("BulletsFast");
        Time.timeScale = 1;
        choiceObject.SetActive(false);
    }

    private void TurnOffWater()
    {
        selected.Add("Lava");
        Time.timeScale = 1;
        lava.SetActive(true);
        choiceObject.SetActive(false);
    }
    private void TurnOffLava()
    {
        selected.Add("Water");
        Time.timeScale = 1;
        water.SetActive(true);
        choiceObject.SetActive(false);
    }

    private void ActivateMines()
    {
        selected.Add("Mines");
        Time.timeScale = 1;
        mines.SetActive(true);
        choiceObject.SetActive(false);
    }

    private void ActivateHealthPickups()
    {
        selected.Add("Health");
        Time.timeScale = 1;
        healthPickups.SetActive(true);
        choiceObject.SetActive(false);
    }


    private void Clouds()
    {
        selected.Add("Clouds");
        Time.timeScale = 1;
        clouds.SetActive(true);
        choiceObject.SetActive(false);
    }
    private void Trees()
    {
        selected.Add("Trees");
        Time.timeScale = 1;
        trees.SetActive(true);
        choiceObject.SetActive(false);
    }
}

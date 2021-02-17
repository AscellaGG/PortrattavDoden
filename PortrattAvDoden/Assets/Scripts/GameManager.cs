using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class GameManager : MonoBehaviour
{
    public GameObject[] rooms = new GameObject[5];

    public Text roomText;

    int roomNr;

    public GameObject rightArrow;
    public GameObject leftArrow;

    GameObject currentRoom;
    public GameObject levelParent;
    public GameObject closedRooms;

    public Button openTabletButton;
    public GameObject tablet;

    public bool isLarsHiding;

    public GameObject larsLerin;

    public GameObject kruka;

    public Sprite larsIKruka;

    public Collider2D larsIKrukaCollider;

    public List<string> possiblePasswords;

    // Start is called before the first frame update
    void Start()
    {
        /*for(int i = 0; i < rooms.Length ; i++ )
        {
            //rooms[i].SetActive(false);
        }*/

        possiblePasswords = new List<string>();

        isLarsHiding = false;

        larsIKrukaCollider.enabled = false;

        roomNr = 0;

        currentRoom = levelParent.transform.GetChild(0).gameObject;

        leftArrow.SetActive(false);

        Debug.Log("test");
    }

    // Update is called once per frame
    void Update()
    {
        roomText.text = currentRoom.name;
    }

    public void OpenTablet()
    {
        tablet.gameObject.SetActive(true);
    }
    
    public void CloseTablet()
    {
        tablet.gameObject.SetActive(false);
    }

    public void HideLars()
    {
        if (!isLarsHiding)
        {
            Destroy(larsLerin);
            kruka.GetComponent<SpriteRenderer>().sprite = larsIKruka;
            isLarsHiding = true;
            larsIKrukaCollider.enabled = true;
        }
    }

    public void OpenNextRoom()
    {
        currentRoom.transform.SetParent(closedRooms.transform);
        roomNr += 1;
        rooms[roomNr].transform.SetParent(levelParent.transform);
        currentRoom = levelParent.transform.GetChild(0).gameObject;

        if(roomNr > 0)
        {
            leftArrow.SetActive(true);
        }
        if (roomNr == 4)
        {
            rightArrow.SetActive(false);
        }
    }

    public void OpenPreviousRoom()
    {
        currentRoom.transform.SetParent(closedRooms.transform);
        roomNr -= 1;
        rooms[roomNr].transform.SetParent(levelParent.transform);
        currentRoom = levelParent.transform.GetChild(0).gameObject;

        if (roomNr < 4)
        {
            rightArrow.SetActive(true);
        }
    }
}
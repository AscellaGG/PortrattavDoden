using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;

public class Door : MonoBehaviour
{
    GameManager gameManager;
    //public whatever this door leads to

    public GameObject roomDoorOpens;

    // Start is called before the first frame update
    void Start()
    {
        gameManager = GameObject.Find("Manager").GetComponent<GameManager>();
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    /*private void OnMouseDown()
    {
        if (EventSystem.current.IsPointerOverGameObject())
        {
            Debug.Log("Clicked on the UI");
        }
        else
        {
            //open whatever room door leads to
            OpenRoom();
            //this.gameObject.SetActive(false);
        }
    }
    */

    public void OpenRoom()
    {
        //open room
        this.gameObject.transform.parent.SetParent(gameManager.closedRooms.transform);
        roomDoorOpens.transform.SetParent(gameManager.levelParent.transform);
    }
}

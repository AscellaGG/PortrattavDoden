﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;

public class Interact : MonoBehaviour
{
    public Vector3 startingPosition;
    public Vector3 startingScale;

    public int startOrderinLayer;

    public GameObject greyScreenPrefab;
    GameObject greyScreen;

    public bool largerImage;

    public GameObject latestClickedObject;

    public GameObject zoomObject;

    // Start is called before the first frame update
    public void Start()
    {
        largerImage = false;
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetMouseButtonDown(0))
        {
            InteractWithObject();
        }
    }

    // When you click an interavtable object
    void InteractWithObject()
    {
        if (!EventSystem.current.IsPointerOverGameObject())
        {
            Vector3 mousePos = Camera.main.ScreenToWorldPoint(Input.mousePosition);
            Vector2 mousePos2D = new Vector2(mousePos.x, mousePos.y);

            RaycastHit2D hit = Physics2D.Raycast(mousePos2D, Vector2.zero);

            Debug.Log("0");
            if (hit.collider != null)
            {
                Debug.Log("1"); 
                if (!largerImage)
                {
                    zoomObject = hit.collider.gameObject;
                    Debug.Log(zoomObject);
                }

                latestClickedObject = hit.collider.gameObject;

                var interactable = latestClickedObject.GetComponent<IInteractable>();
                if (interactable == null) return; //quit if last clicked item isnt interactable
                interactable.Interact();

                /*else if (largerImage && hit.collider.gameObject.name == "GreyScreen(Clone)")
                {
                    //reset object to original position
                    latestClickedObject.transform.position = startingPosition;
                    latestClickedObject.transform.localScale = startingScale;
                    latestClickedObject.GetComponent<SpriteRenderer>().sortingOrder = startOrderinLayer;

                    Destroy(greyScreen);
                    largerImage = false;
                }*/
            }
            else if(hit.collider == null)
            {
                //reset object to original position
                zoomObject.transform.position = startingPosition;
                zoomObject.transform.localScale = startingScale;
                zoomObject.GetComponent<SpriteRenderer>().sortingOrder = startOrderinLayer;

                largerImage = false;
                Destroy(greyScreen);
            }
        }
    }

    public void Zoom(int scaleConstant)
    {
        startingPosition = zoomObject.transform.position;
        startingScale = zoomObject.transform.localScale;
        startOrderinLayer = zoomObject.GetComponent<SpriteRenderer>().sortingOrder;

        //make object larger
        largerImage = true;

        greyScreen = Instantiate(greyScreenPrefab);

        zoomObject.GetComponent<SpriteRenderer>().sortingOrder = 2;
        zoomObject.transform.position = new Vector3(0, 0, 0);

        zoomObject.transform.localScale = new Vector3(startingScale.x * scaleConstant, startingScale.y * scaleConstant, 0);
    }
}

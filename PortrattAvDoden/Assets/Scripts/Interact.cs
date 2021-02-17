using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;

public class Interact : MonoBehaviour
{
    Vector3 startingPosition;
    Vector3 startingScale;

    int startOrderinLayer;

    public GameObject greyScreenPrefab;
    GameObject greyScreen;

    public bool largerImage;

    public GameObject latestClickedObject;

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
            if (hit.collider != null)
            {
                if (largerImage && hit.collider.gameObject.name == "GreyScreen(Clone)")
                {
                    //reset object to original position
                    latestClickedObject.transform.position = startingPosition;
                    latestClickedObject.transform.localScale = startingScale;
                    latestClickedObject.GetComponent<SpriteRenderer>().sortingOrder = startOrderinLayer;

                    Destroy(greyScreen);
                    largerImage = false;
                }
                else
                {
                    if (!largerImage)
                    {
                        latestClickedObject = hit.collider.gameObject;
                        Debug.Log(latestClickedObject);

                        if (latestClickedObject.tag == "Door") //remove
                        {
                            latestClickedObject.GetComponent<Door>().OpenRoom();
                        }
                        else
                        {
                            if (latestClickedObject.GetComponent<DialogueTrigger>() != null)
                            {
                                latestClickedObject.GetComponent<DialogueTrigger>().TriggerDialogue();
                            }

                            if (latestClickedObject.tag == "Interactable" )
                            {
                                //get original position, scale and sorting order
                                startingPosition = latestClickedObject.transform.position;
                                startingScale = latestClickedObject.transform.localScale;
                                startOrderinLayer = latestClickedObject.GetComponent<SpriteRenderer>().sortingOrder;

                                //make object larger
                                largerImage = true;

                                greyScreen = Instantiate(greyScreenPrefab);

                                latestClickedObject.GetComponent<SpriteRenderer>().sortingOrder = 2;
                                latestClickedObject.transform.position = new Vector3(0, 0, 0);
                                if(latestClickedObject.name == "Cattismobil")
                                {
                                    latestClickedObject.transform.localScale = new Vector3(startingScale.x * 5, startingScale.y * 5, 0);
                                }
                                else
                                {
                                    latestClickedObject.transform.localScale = new Vector3(startingScale.x * 2, startingScale.y * 2, 0);
                                }
                            }
                        }
                    }
                }
            }
        }
    }
}

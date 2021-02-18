using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GreyScreen : MonoBehaviour, IInteractable
{
    Interact interact;

    public void Interact()
    {
        interact = FindObjectOfType<Interact>();
        if(interact.largerImage)
        {
            interact.latestClickedObject.transform.position = interact.startingPosition;
            interact.latestClickedObject.transform.localScale = interact.startingScale;
            interact.latestClickedObject.GetComponent<SpriteRenderer>().sortingOrder = interact.startOrderinLayer;

            interact.largerImage = false;
            Destroy(this.gameObject);
        }
    }
}

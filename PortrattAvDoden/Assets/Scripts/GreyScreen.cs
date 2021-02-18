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
            interact.zoomObject.transform.position = interact.startingPosition;
            interact.zoomObject.transform.localScale = interact.startingScale;
            interact.zoomObject.GetComponent<SpriteRenderer>().sortingOrder = interact.startOrderinLayer;

            interact.largerImage = false;
            Destroy(this.gameObject);
        }
    }
}

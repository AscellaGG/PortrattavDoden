using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class InteractableObject : MonoBehaviour, IInteractable
{
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void Interact()
    {
        FindObjectOfType<Interact>().Zoom(2);

        if(GetComponent<DialogueTrigger>() != null)
        {
            GetComponent<DialogueTrigger>().TriggerDialogue();
        }
    }
}

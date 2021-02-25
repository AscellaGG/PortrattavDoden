using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Phone : MonoBehaviour, IInteractable, IInventoryItem
{
    /*public GameManager gameManager;

    public Interact interactScript;

    SpriteRenderer spriteRenderer;

    public Sprite frontOfPhone;

    public bool frontFacing;

    DialogueTrigger dialogueTrigger;

    public string password;

    public DialogueManager dialogueManager;*/

    public GameObject phoneButton;

    // Start is called before the first frame update
    void Start()
    {
        /*spriteRenderer = gameObject.GetComponent<SpriteRenderer>();

        frontFacing = false;

        dialogueTrigger = this.GetComponent<DialogueTrigger>();*/

        //dialogueTrigger.dialogue.hasOptions = false;
    }

    // Update is called once per frame
    void Update()
    {
        //if we have a password guess, allow us to try it
    }

    private void OnMouseDown()
    {
        /*if(interactScript.largerImage && interactScript.zoomObject.name == this.name)
        {
            Debug.Log("turn phone around");
            spriteRenderer.sprite = frontOfPhone;
            transform.rotation = new Quaternion(0, 0, 0, 0);
            frontFacing = true;
        }

        if(interactScript.largerImage && frontFacing)
        {
            //open options for password or smth
            dialogueTrigger.dialogue.hasOptions = true;

            //change text on buttons to guesses?
            //dialogueManager.optionButtons[0].GetComponent<Text>().text = "Lås upp mobilen";
            dialogueManager.dialogueOptions.optionButtons[0].GetComponent<Text>().text = "Lås upp mobilen";
            dialogueManager.dialogueOptions.GuessPhonePassword();

            //dialogueManager.ShowPasswordGuess();    
            dialogueTrigger.TriggerDialogue();


        }*/
    }

    public void UseItem()
    {
        Debug.Log("using" + gameObject.name);
    }

    public void Interact()
    {
        FindObjectOfType<Inventory>().AddToInventory(phoneButton);

        Destroy(this.gameObject);

        /*if (this.GetComponent<DialogueTrigger>() != null)
        {
            this.GetComponent<DialogueTrigger>().TriggerDialogue();
        }

        if(!interactScript.largerImage)
        {
            interactScript.Zoom(5);
        }
        else if(interactScript.largerImage && frontFacing)
        {
            //open options for password or smth
            dialogueTrigger.dialogue.hasOptions = true;

            //change text on buttons to guesses?
            //dialogueManager.optionButtons[0].GetComponent<Text>().text = "Lås upp mobilen";
            dialogueManager.dialogueOptions.optionButtons[0].GetComponent<Text>().text = "Lås upp mobilen";
            dialogueManager.dialogueOptions.GuessPhonePassword();

            //dialogueManager.ShowPasswordGuess();    
            dialogueTrigger.TriggerDialogue();
        }
        else if (interactScript.largerImage)
        {
            Debug.Log("turn phone around");
            spriteRenderer.sprite = frontOfPhone;
            transform.rotation = new Quaternion(0, 0, 0, 0);
            frontFacing = true;
        }*/
    }
}

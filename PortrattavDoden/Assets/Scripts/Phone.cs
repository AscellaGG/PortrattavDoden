using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Phone : MonoBehaviour
{
    public GameManager gameManager;

    public Interact interactScript;

    SpriteRenderer spriteRenderer;

    public Sprite frontOfPhone;

    public bool frontFacing;

    DialogueTrigger dialogueTrigger;

    public string password;

    public DialogueManager dialogueManager;

    // Start is called before the first frame update
    void Start()
    {
        spriteRenderer = gameObject.GetComponent<SpriteRenderer>();

        frontFacing = false;

        dialogueTrigger = this.GetComponent<DialogueTrigger>();

        dialogueTrigger.dialogue.hasOptions = false;
    }

    // Update is called once per frame
    void Update()
    {
        //if we have a password guess, allow us to try it
    }

    private void OnMouseDown()
    {
        if(interactScript.largerImage && interactScript.latestClickedObject.name == this.name)
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


        }
    }

    void UnlockPhone()
    {

    }
}

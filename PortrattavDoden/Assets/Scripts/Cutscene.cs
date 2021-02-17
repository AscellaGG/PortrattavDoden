using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class Cutscene : MonoBehaviour
{

    DialogueManager dialogueManager;

    // Start is called before the first frame update
    void Start()
    {
        dialogueManager = this.GetComponent<DialogueManager>();

        this.GetComponent<DialogueTrigger>().TriggerDialogue();
    }

    // Update is called once per frame
    void Update()
    {
        if(dialogueManager.isDialogueActive == false)
        {
            SceneManager.LoadScene("Game");
        }
    }
}

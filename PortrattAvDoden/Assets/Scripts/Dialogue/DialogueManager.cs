using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class DialogueManager : MonoBehaviour
{
    GameManager gameManager;

    public Queue<string> sentences;

    public Queue<string> options;

    public TMP_Text nameText;
    public TMP_Text dialogueText;

    public GameObject dialogueBox;

    public bool isDialogueActive;

    public Button[] optionButtons = new Button[3];

    // Start is called before the first frame update
    void Start()
    {
        if(this.GetComponent<GameManager>() != null)
        {
            gameManager = GetComponent<GameManager>();
        }

        sentences = new Queue<string>();

        options = new Queue<string>();

        dialogueBox.SetActive(false);

        //dialogueOptions = this.GetComponent<DialogueOptions>();
    }

    public void StartDialogue(Dialogue dialogue)
    {
        dialogueBox.SetActive(true);

        isDialogueActive = true;

        for (int i = 0; i < optionButtons.Length; i++)
        {
            optionButtons[i].gameObject.SetActive(false);
        }

        for (int i = 0; i < dialogue.options.Length; i++)
        {
            optionButtons[i].gameObject.SetActive(true);
            optionButtons[i].GetComponentInChildren<TMP_Text>().text = dialogue.options[i].optionText;
            optionButtons[i].onClick.AddListener(delegate { StartNextDialogue(dialogue.options[i - 1]); });
        }

        /*if(dialogue.hasOptions)
        {
            foreach(string option in dialogue.options)
            {
                options.Enqueue(option);
            }

            dialogueOptions.EnableDialogueOptions(dialogue.options.Length);

            for (int i = 0; i < dialogueOptions.optionButtons.Length; i++)
            {
                if (dialogueOptions.optionButtons[i].IsActive())
                {
                    dialogueOptions.optionButtons[i].GetComponent<Text>().text = options.Dequeue();
                }
            }

            dialogueOptions.test();
        }
        /*else if(!dialogue.hasOptions)
        {
            dialogueOptions.DisableDialogueOptions();
        }*/

        Debug.Log("Starting conversation");

        if(dialogue.name != null)
        {
            nameText.text = dialogue.name;
        }
        else
        {
            nameText.text = "";
        }

        sentences.Clear();

        foreach(string sentence in dialogue.sentences)
        {
            sentences.Enqueue(sentence);
        }

        DisplayNextSentence();
    }

    void StartNextDialogue(Response option)
    {
        Debug.Log("starting next dialogue");
        StartDialogue(option.secondaryDialogue);
    }

    public void DisplayNextSentence()
    {
        if (sentences.Count == 0)
        {
            EndDialogue();
            return;
        }

        string sentence = sentences.Dequeue();

        StopAllCoroutines();
        StartCoroutine(TypeSentence(sentence));
    }

    IEnumerator TypeSentence (string sentence)
    {
        dialogueText.text = "";

        foreach(char letter in sentence.ToCharArray())
        {
            dialogueText.text += letter;
            yield return new WaitForSeconds(0.01f);
        }
    }

    void EndDialogue()
    {
        Debug.Log("End of conversation");
        dialogueBox.SetActive(false);

        isDialogueActive = false;
    }
}

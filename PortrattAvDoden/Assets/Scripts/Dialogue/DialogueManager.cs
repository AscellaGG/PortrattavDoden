using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class DialogueManager : MonoBehaviour
{
    GameManager gameManager;

    public DialogueOptions dialogueOptions;

    public Queue<string> sentences;

    public Queue<string> passwordGuess;

    public Queue<string> options;

    public Text nameText;
    public Text dialogueText;

    public GameObject dialogueBox;

    public bool isDialogueActive;

    // Start is called before the first frame update
    void Start()
    {
        if(this.GetComponent<GameManager>() != null)
        {
            gameManager = GetComponent<GameManager>();
        }

        sentences = new Queue<string>();

        passwordGuess = new Queue<string>();

        options = new Queue<string>();

        dialogueBox.SetActive(false);

        dialogueOptions = this.GetComponent<DialogueOptions>();
    }

    public void StartDialogue(Dialogue dialogue)
    {
        dialogueBox.SetActive(true);

        isDialogueActive = true;

        if(dialogue.hasOptions)
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

        Debug.Log("Starting conversation with " + dialogue.name);

        if(dialogue.hasName)
        {
            nameText.text = dialogue.name;
        }
        else
        {
            nameText.text = "";
        }

        sentences.Clear();
        passwordGuess.Clear();

        foreach(string sentence in dialogue.sentences)
        {
            sentences.Enqueue(sentence);
        }

        foreach(string sentence in dialogue.passwordGuessDialogue)
        {
            passwordGuess.Enqueue(sentence);
        }

        if(this.GetComponent<GameManager>() != null)
        {
            gameManager.possiblePasswords.Add(dialogue.passwordGuess);
        }

        DisplayNextSentence();
    }

    void GetNextOption()
    {

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

    public void ShowPasswordGuess()
    {
        if (passwordGuess.Count == 0)
        {
            EndDialogue();
            return;
        }

        string sentence = passwordGuess.Dequeue();

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

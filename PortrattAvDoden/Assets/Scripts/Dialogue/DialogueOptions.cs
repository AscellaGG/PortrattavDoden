using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class DialogueOptions : MonoBehaviour
{
    public Button[] optionButtons = new Button[3];

    public DialogueManager dialogueManager;

    public GameManager gameManager;

    string[] stringy;

    string cattisFavTavla;

    // Start is called before the first frame update
    void Start()
    {
        stringy = new string[optionButtons.Length];
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void EnableDialogueOptions(int dialogueOptions)
    {
        for(int i = 0; i < dialogueOptions; i++)
        {
            optionButtons[i].gameObject.SetActive(true);
        }
    }

    public void DisableDialogueOptions()
    {
        for (int i = 0; i < optionButtons.Length; i++)
        {
            optionButtons[i].gameObject.SetActive(false);
        }
    }

    public void test()
    {
        for (int x = 0; x < optionButtons.Length -1; x++)
        {
            stringy[x] = optionButtons[x].GetComponent<Text>().text;
            optionButtons[x].onClick.AddListener(() => WhatToDo(stringy[x]));
        }
    }

    public void WhatToDo(string stringy)
    {
        if(stringy == cattisFavTavla) 
        {
            Debug.Log("stuff");
            dialogueManager.ShowPasswordGuess();
        }
        else if(stringy == "Lås upp mobilen")
        {
            GuessPhonePassword();
        }
    } 

    public void GuessPhonePassword()
    {
        EnableDialogueOptions(gameManager.possiblePasswords.Count);

        for(int i = 0; i < gameManager.possiblePasswords.Count - 1; i++)
        {
            optionButtons[i].GetComponent<Text>().text = gameManager.possiblePasswords[i];
        }
    }
}

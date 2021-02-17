using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[System.Serializable]
public class Dialogue 
{
    public bool alivePerson;

    public string name;

    public bool hasOptions;

    public bool hasName;

    public string passwordGuess;

    [TextArea(1, 5)]
    public string[] options;

    [TextArea(3,10)]
    public string[] sentences;

    [TextArea(3,10)]
    public string[] passwordGuessDialogue;
}

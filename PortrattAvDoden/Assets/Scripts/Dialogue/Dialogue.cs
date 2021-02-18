using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(fileName ="New Dialogue", menuName = "Dialogue")]
public class Dialogue : ScriptableObject
{
    /*public bool alivePerson;

    public new string name;

    public bool hasOptions;

    public bool hasName;

    public string passwordGuess;*/

    [TextArea(3,10)]
    public string[] sentences;
    
    public Response[] options;

    /*[TextArea(3,10)]
    public string[] passwordGuessDialogue;*/
}

[System.Serializable]
public class Response
{
    [TextArea(1, 1)]
    public string optionText;

    public Dialogue secondaryDialogue;
}

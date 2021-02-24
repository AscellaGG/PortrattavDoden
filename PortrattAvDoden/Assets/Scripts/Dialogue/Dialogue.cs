using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(fileName ="New Dialogue", menuName ="Dialogue")]
public class Dialogue : ScriptableObject
{

    public new string name;

    public Response[] options;

    [TextArea(1,5)]
    public string[] sentences;
}

[System.Serializable]
public class Response
{
    [TextArea(1, 1)]
    public string optionText;

    public Dialogue secondaryDialogue;
}
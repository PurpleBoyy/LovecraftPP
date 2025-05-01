using UnityEngine;
using System.Collections.Generic;


[System.Serializable]
public class DialogueClass
{
    public string charName;
    public List<string> line = new List<string>();
}

[System.Serializable]

public class DialogueList
{
    public int pauseIndex;
    public List<DialogueClass> Dialogue = new List<DialogueClass>();
}

using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[System.Serializable]
public class DialogueNode
{
    public string Id;
    public string dialogueText;
    public List<string> variants = new List<string>();
    public Rect position = new(0, 0, 200, 100);
}

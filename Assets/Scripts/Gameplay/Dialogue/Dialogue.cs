using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(fileName = "New Dialogue")]
public class Dialogue: ScriptableObject
{
    [SerializeField]
    List<DialogueNode> dialogueNodes = new List<DialogueNode>();

    Dictionary<string, DialogueNode> nodeLookup = new Dictionary<string, DialogueNode>();

#if UNITY_EDITOR
    private void Awake()
    {
        if (dialogueNodes.Count == 0)
        { 
            DialogueNode startNode = new DialogueNode();
            startNode.Id = Guid.NewGuid().ToString();
            dialogueNodes.Add(startNode);
        }
    }
#endif
    private void OnValidate()
    {
        nodeLookup.Clear();

        foreach (DialogueNode node in GetAllNodes())
        {
            nodeLookup[node.Id] = node;
        }
    }

    public IEnumerable<DialogueNode> GetAllChildren(DialogueNode parentNode)
    {
        foreach (string childId in parentNode.variants)
        {
            if (nodeLookup.ContainsKey(childId))
            {
                yield return nodeLookup[childId];
            }
        }
    }
    public IEnumerable<DialogueNode> GetAllNodes()
    {
        return dialogueNodes;
    }

    public DialogueNode GetRootNode()
    {
        return dialogueNodes[0];
    }

    public void CreateNode(DialogueNode parent)
    {
        DialogueNode newNode = new DialogueNode();

        newNode.Id = Guid.NewGuid().ToString();
        parent.variants.Add(newNode.Id);
        dialogueNodes.Add(newNode);
        OnValidate();
    }

    public void DeleteNode(DialogueNode node)
    {
        dialogueNodes.Remove(node);
        OnValidate();

        foreach (DialogueNode dialogueNode in GetAllNodes())
        {
            node.variants.Remove(node.Id);
        }
    }
}

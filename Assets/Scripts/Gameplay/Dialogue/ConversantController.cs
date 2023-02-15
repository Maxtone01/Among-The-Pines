using System.Collections;
using System.Collections.Generic;
using System.Linq;
using UnityEngine;

public class ConversantController : MonoBehaviour
{
    [SerializeField]
    Dialogue dialogueTree;
    DialogueNode currentNode = null;

    private void Awake()
    {
        currentNode = dialogueTree.GetRootNode();
    }

    public string GetText()
    {
        if (currentNode == null)
        {
            return "Dialogue is empty!";
        }

        return currentNode.GetText();
    }

    public IEnumerable<string> GetChoiceVariants()
    {
        yield return "Abaoba";
        yield return "Aboba";
    }

    public void SelectNextDialogueVariant()
    {
        DialogueNode[] variant = dialogueTree.GetAllChildren(currentNode).ToArray();
        int index = Random.Range(0, variant.Count());
        currentNode = variant[index];
    }

    public bool HasNext()
    {
        return dialogueTree.GetAllChildren(currentNode).Count() > 0;
    }
}

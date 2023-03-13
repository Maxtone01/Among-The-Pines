using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CharacterConversant : MonoBehaviour
{
    PlayerController dialogueController;
    [SerializeField] 
    Dialogue dialogue = null;
    [SerializeField]
    private float viewRadius;
    [SerializeField]
    string characterName;
    public LayerMask _playerMask;

    public void StartDialogue(PlayerController dialogueController)
    {
        dialogueController.GetComponent<ConversantController>().StartDialogue(this, dialogue);
    }

    public void EndDialogue(PlayerController dialogueController)
    {
        dialogueController.GetComponent<ConversantController>().QuitDialogue();
    }

    private void OnTriggerEnter(Collider collider)
    {
        if (collider.gameObject.CompareTag("Player"))
        {
            dialogueController = collider.gameObject.GetComponent<PlayerController>();
            StartDialogue(dialogueController);
        }
    }

    private void OnTriggerExit(Collider collider)
    {
        if (collider.gameObject.CompareTag("Player"))
        {
            EndDialogue(dialogueController);
            dialogueController = null;
        }
    }

    public void TestExitAction()
    {
        Debug.Log("Exit!");
    }

    public void TestEnterAction()
    {
        Debug.Log("Enter!!");
    }

    public string GetName()
    {
        return characterName;
    }
}

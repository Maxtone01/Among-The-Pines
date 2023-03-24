using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

public class PlayerController : MonoBehaviour
{
    internal Animator animator;
    private GameObject dialogueController;
    private QuestTooltipUi questTooltip;
    [SerializeField] GameObject tooltipGameObject;
    PauseMenu _pauseMenu;
    [SerializeField] QuestCompletion qCompl;
    [SerializeField] QuestList questList;
    [SerializeField] GameObject cameraState;
    [SerializeField] ConversantController characterConversant;
    [SerializeField] MovementScript moveScript;
    [SerializeField]
    private Quest quest;


    private List<string> questNames = new List<string>();
    private bool isTooltipActive = false;

    public void Start()
    {
        _pauseMenu = GameObject.FindGameObjectWithTag("UI").GetComponent<PauseMenu>();
        questTooltip = tooltipGameObject.GetComponent<QuestTooltipUi>();
        animator = GetComponent<Animator>();

        questList.AddQuest(quest);
    }

    private void Update()
    {
        if (Input.GetMouseButtonDown(0))
        {
            dialogueController = GameObject.FindGameObjectWithTag("Dialogue Panel");
            if (dialogueController == null)
            {
                return;
            }
            else
            {
                DialogueUI dialogue = dialogueController.GetComponent<DialogueUI>();
                dialogue.conversantController.SelectNextDialogueVariant();
            }
        }
        if (Input.GetKeyDown(KeyCode.Tab))
        {
            if (!isTooltipActive)
            {
                isTooltipActive = true;
                tooltipGameObject.SetActive(true);
                foreach (QuestStates questState in questList.GetQuests())
                {
                    questTooltip.Setup(questState);
                }
            }
            else 
            {
                isTooltipActive = false;
                tooltipGameObject.SetActive(false);
            }
        }
    }
    

    private void OnCollisionEnter(Collision collision)
    {
        if (collision.gameObject.CompareTag("Collectable"))
        {
            CollectItem(collision);
        }
    }

    private void CollectItem(Collision collision)
    {
        Destroy(collision.gameObject);
        if (collision.gameObject.name == "Flower")
        {
            foreach (QuestStates questState in questList.GetQuests())
            {
                Quest quest = questState.GetQuest();
                foreach (Quest.Objective qObjective in quest.GetOjectives())
                {
                    if (qObjective.itemToCollect > qObjective.itemCollected)
                    {
                        qObjective.itemCollected++;
                    }
                    if (qObjective.itemCollected >= 7)
                    {
                        qCompl.CompleteObjective(quest);
                    }
                }
            }
        }
    }

    public void Idle()
    {
        animator.SetFloat("State", 0);
    }

    public void Move(float speed)
    {
        transform.Translate(transform.forward * speed * Time.deltaTime, Space.World);
        animator.SetFloat("State", 1);
    }
}

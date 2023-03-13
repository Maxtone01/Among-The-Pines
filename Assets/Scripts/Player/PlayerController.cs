using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

public class PlayerController : MonoBehaviour
{
    internal Animator animator;

    [SerializeField] QuestCompletion qCompl;
    [SerializeField] QuestList questList;
    [SerializeField] List<Quest> qList = new List<Quest>();
    [SerializeField] GameObject cameraState;
    [SerializeField] ConversantController characterConversant;
    [SerializeField] MovementScript moveScript;

    private List<string> questNames = new List<string>();

    public void Start()
    {
        animator = GetComponent<Animator>();
    }

    private void OnCollisionEnter(Collision collision)
    {
        if (collision.gameObject.CompareTag("Acorn"))
        {
            CollectAcorn(collision);
        }
    }

    private void CollectAcorn(Collision collision)
    {
        int acorn = 0;
        acorn++;

        if (acorn == 1)
        {
            foreach (QuestStates questName in questList.GetQuests())
            {
                if (questName.GetQuest().GetTitle() == "Знайти 6 жолудів")
                {
                    qCompl.CompleteObjective(qList[0]);
                    Destroy(collision.gameObject);
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

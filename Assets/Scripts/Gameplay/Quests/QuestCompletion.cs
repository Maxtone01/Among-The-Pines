using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class QuestCompletion : MonoBehaviour
{
    //[SerializeField]
    //public Quest quest;
    [SerializeField] string objective;

    public void CompleteObjective(Quest quest)
    {
        QuestList questList = GameObject.FindGameObjectWithTag("Player").GetComponent<QuestList>();
        questList.CompleteObjective(quest, objective);
    }
}

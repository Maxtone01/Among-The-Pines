using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class QuestList : MonoBehaviour
{
    List<QuestStates> questList = new List<QuestStates>();

    public Action onQuestUpdated;

    public void AddQuest(Quest quest)
    {
        if (HasQuest(quest))
        {
            return;
        }
        QuestStates newState = new QuestStates(quest);
        questList.Add(newState);
        if (onQuestUpdated != null)
        {
            onQuestUpdated();
        }
    }

    internal void CompleteObjective(Quest quest, string objective)
    {
        QuestStates state = GetQuestState(quest);
        state.CompleteObjective(objective);
        if (onQuestUpdated != null)
        {
            onQuestUpdated();
        }
    }

    public bool HasQuest(Quest quest)
    {
        return GetQuestState(quest) != null;
    }

    public IEnumerable<QuestStates> GetQuests()
    {
        return questList;
    }

    private QuestStates GetQuestState(Quest quest)
    {
        foreach (QuestStates state in questList)
        {
            if (state.GetQuest() == quest)
            {
                return state;
            }
        }
        return null;
    }
}

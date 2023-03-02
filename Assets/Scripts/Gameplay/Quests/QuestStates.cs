using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[System.Serializable]
public class QuestStates
{
    [SerializeField] Quest quest;
    [SerializeField] List<string> completedObjectives;

    public Quest GetQuest()
    {
        return quest;
    }

    public int GetCompletedQuests()
    { 
        return completedObjectives.Count;
    }

    public bool IsCompletedQuest(string objective) 
    {
        return completedObjectives.Contains(objective);
    }
}

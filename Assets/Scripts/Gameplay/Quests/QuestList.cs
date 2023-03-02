using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class QuestList : MonoBehaviour
{
    [SerializeField] QuestStates[] states;

    public IEnumerable<QuestStates> GetStates()
    {
        return states;
    }
}

using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

public class DialogueTrigger : MonoBehaviour
{
    [SerializeField]
    public string triggerActions;

    [SerializeField]
    UnityEvent onTrigger;

    public void TriggerAction(string actionToTrigger)
    {
        if (actionToTrigger == triggerActions)
        {
            onTrigger.Invoke();
        }
    }
}

using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

public class DialogueTrigger : MonoBehaviour
{
    [SerializeField]
    string triggerAction;
    [SerializeField]
    UnityEvent onTrigger;

    public void TriggerAction(string actionToTrigger)
    {
        if (actionToTrigger == triggerAction)
        {
            onTrigger.Invoke();
        }
    }
}

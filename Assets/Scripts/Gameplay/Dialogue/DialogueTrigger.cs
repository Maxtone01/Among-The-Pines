using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

public class DialogueTrigger : MonoBehaviour
{
    //[SerializeField]
    //string triggerAction;
    public enum TriggerActions
    { 
        Exit_Dialogue,
        Give_Quest,
        Start_Attack,
    };
    [SerializeField]
    public TriggerActions triggerActions;

    [SerializeField]
    UnityEvent onTrigger;

    public void TriggerAction(string actionToTrigger)
    {
        switch (triggerActions)
        { 
            case TriggerActions.Exit_Dialogue:
                onTrigger.Invoke();
                break;
            case TriggerActions.Give_Quest:
                onTrigger.Invoke();
                break; 
            case TriggerActions.Start_Attack:
                onTrigger.Invoke();
                break;
        }
        //if (actionToTrigger == )
        //{
        //    onTrigger.Invoke();
        //}
        //foreach (string trigAction in Enum.GetNames(typeof(TriggerActions)))
        //{
        //    if (actionToTrigger == trigAction)
        //    {
        //        onTrigger.Invoke();
        //    }
        //}
    }
}

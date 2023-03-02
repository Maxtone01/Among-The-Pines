using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class QuestUI : MonoBehaviour
{
    [SerializeField] QuestItemUi questPrefab;

    public void Start()
    {
        foreach (Transform uiElement in this.transform)
        {
            Destroy(uiElement.gameObject);
        }

        QuestList questList = GameObject.FindGameObjectWithTag("Player").GetComponent<QuestList>();

        foreach (QuestStates state in questList.GetStates()) 
        {
            QuestItemUi uiInstance = Instantiate<QuestItemUi>(questPrefab, transform);
            uiInstance.Setup(state);
        }
    }
}

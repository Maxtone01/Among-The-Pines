using System;
using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class QuestTooltipUi : MonoBehaviour
{
    [SerializeField] TextMeshProUGUI titleText;
    [SerializeField] Transform objectiveContainer;
    [SerializeField] GameObject objectivePrefab;
    [SerializeField] GameObject objectiveIncompletedPrefab;
    public void Setup(QuestStates state)
    {
        Quest quest = state.GetQuest();

        ClearPrefab();

        titleText.text = quest.GetTitle();

        foreach (Quest.Objective item in quest.GetOjectives())
        {
            GameObject prefab = objectiveIncompletedPrefab;

            if (state.IsCompletedQuest(item.reference))
            {
                prefab = objectivePrefab;
            }
            GameObject objInstance = Instantiate(prefab, objectiveContainer);
            TextMeshProUGUI objText = objInstance.GetComponentInChildren<TextMeshProUGUI>();
            objText.text = item.description;
        }
    }

    private void ClearPrefab()
    {
        foreach (Transform containerChild in objectiveContainer.transform)
        {
            Destroy(containerChild.gameObject);
        }
    }
}

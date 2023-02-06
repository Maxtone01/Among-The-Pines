using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(menuName = "New Quest")]
public class Quest : ScriptableObject
{
    [SerializeField]
    List<string> tasks;

    public void AddTask(string task)
    {
        tasks.Add(task);
    }

    public IEnumerable<string> GetTasks()
    {
        return tasks;
    }
}

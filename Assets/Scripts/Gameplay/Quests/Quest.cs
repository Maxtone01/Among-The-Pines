using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(menuName = "New Quest")]
public class Quest : ScriptableObject
{
    [SerializeField] string[] objectives;

    public string GetTitle()
    {
        return name;
    }

    public int GetObjectiveCount()
    {
        return objectives.Length;
    }

    public IEnumerable<string> GetOjectives()
    {
        return objectives;
    }

}

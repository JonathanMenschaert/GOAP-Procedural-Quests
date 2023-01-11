using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GoapGoal : MonoBehaviour
{
    public virtual bool IsValid()
    {
        return false;
    }

    public virtual int Priority()
    {
        return 0;
    }

    public virtual Dictionary<string, bool> GetDesiredState()
    {
        var dictionary = new Dictionary<string, bool>();
        foreach(KeyValuePair<string, bool> entry in dictionary)
        {
            ent
        }
        return new Dictionary<string, bool>();
    }
}

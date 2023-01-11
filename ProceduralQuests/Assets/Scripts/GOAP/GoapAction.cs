using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GoapAction : MonoBehaviour
{
    public void OnEnable()
    {
        GoapPlanner.Instance.RegisterAction(this);
    }

    public void OnDisable()
    {
        GoapPlanner.Instance.UnregisterAction(this);
    }

    public virtual bool IsValid()
    {
        return false;
    }

    public virtual int GetCost()
    {
        return 10000;
    }

    public virtual Dictionary<string, bool> GetEffects()
    {
        return new Dictionary<string, bool>();
    }

    public virtual Dictionary<string, bool> GetPreconditions()
    {
        return new Dictionary<string, bool>();
    }
}

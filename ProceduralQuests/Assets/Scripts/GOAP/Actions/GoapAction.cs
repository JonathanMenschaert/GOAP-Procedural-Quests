using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GoapAction : MonoBehaviour
{
    protected Dictionary<string, bool> m_Effects = new Dictionary<string, bool>();

    protected Dictionary<string, bool> m_Preconditions = new Dictionary<string, bool>();

    [SerializeField]
    protected List<WorldState.State> m_FillEffects;

    [SerializeField]
    protected List<WorldState.State> m_FillConditions;

    public void Awake()
    {
        foreach(var state in m_FillEffects)
        {
            m_Effects[state.WorldState] = state.Value;
        }

        foreach (var state in m_FillConditions)
        {
            m_Preconditions[state.WorldState] = state.Value;
        }
    }

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
        return m_Effects;
    }

    public virtual Dictionary<string, bool> GetPreconditions()
    {
        return m_Preconditions;
    }
}

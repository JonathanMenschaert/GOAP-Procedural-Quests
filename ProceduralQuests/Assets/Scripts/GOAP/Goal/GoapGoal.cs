using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GoapGoal : MonoBehaviour
{

    protected Dictionary<string, bool> m_Conditions = new Dictionary<string, bool>();

    [SerializeField]
    protected List<WorldState.State> m_FillConditions;

    public void Awake()
    {
        foreach (var state in m_FillConditions)
        {
            m_Conditions[state.WorldState] = state.Value;
        }
        GoapPlanner.Instance.GeneratePlan(this);
    }

    public void Start()
    {
        GoapPlanner.Instance.GeneratePlan(this);
    }

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
        return m_Conditions;
    }
}

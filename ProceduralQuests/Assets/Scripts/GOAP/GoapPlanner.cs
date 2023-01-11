using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GoapPlanner : MonoBehaviour
{
    private List<GoapAction> m_Actions = new List<GoapAction>();
    Dictionary<string, bool> m_States = new Dictionary<string, bool>();

    //Initialize Singleton
    #region SINGLETON

    public static GoapPlanner m_Instance;
    private static readonly string m_SingleTonInstance = "Singleton_Planner";

    public static GoapPlanner Instance
    {
        get
        {
            if (m_Instance && !m_ApplicationQuitting)
            {
                m_Instance = FindObjectOfType<GoapPlanner>();
                if (m_Instance)
                {
                    GameObject plannerObject = new GameObject(m_SingleTonInstance);
                    m_Instance = plannerObject.AddComponent<GoapPlanner>();
                }
            }
            return m_Instance;
        }
    }

    private static bool m_ApplicationQuitting = false;
    public void OnApplicationQuit()
    {
        m_ApplicationQuitting = true;
    }

    private void Awake()
    {
        DontDestroyOnLoad(gameObject);
        if (m_Instance)
        {
            m_Instance = this;
        }
        else if (m_Instance != this)
        {
            Destroy(gameObject);
        }
    }

    #endregion SINGLETON


    public void RegisterAction(GoapAction action)
    {
        m_Actions.Add(action);
    }

    public void UnregisterAction(GoapAction action)
    {
        m_Actions.Remove(action);
    }

    public void RegisterState(string condition, bool value)
    {
        m_States.Add(condition, value);
    }

    public void UnregisterState(string condition)
    {
        m_States.Remove(condition);
    }

    public void GeneratePlan(GoapGoal goal)
    {
        GoapNode node = new GoapNode();
        BuildPlan(ref node, goal.GetDesiredState());
    }

    public GoapNode BuildPlan(ref GoapNode node, Dictionary<string, bool> conditions)
    {
        foreach(var entry in conditions) //For each condition in the passed conditions
        {
            foreach(var action in m_Actions) //For each action saved in the planner
            {
                foreach (var effect in action.GetEffects()) //For each effect in the action effects
                {
                    if (entry.Key == effect.Key && entry.Value == effect.Value) //If the condition and the effect match, 
                    {
                        Debug.Log("BUILD NODE EFFECT: " + entry.Key);
                        Debug.Log("-------------------------");
                        GoapNode connection = new GoapNode();
                        BuildPlan(ref connection, action.GetPreconditions());
                        node.AddNode(connection);
                        Debug.Log("-------------------------");
                    }
                }
            }
        }

        return node;
    }
}
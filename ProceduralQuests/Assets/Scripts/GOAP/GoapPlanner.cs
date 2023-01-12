using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GoapPlanner : MonoBehaviour
{
    private List<GoapAction> m_Actions = new List<GoapAction>();
    private Dictionary<string, GoapGoal> m_Goals = new Dictionary<string, GoapGoal>();

    //Initialize Singleton
    #region SINGLETON

    public static GoapPlanner m_Instance;
    private static readonly string m_SingleTonInstance = "Singleton_Planner";

    public static GoapPlanner Instance
    {
        get
        {
            if (m_Instance == null && !m_ApplicationQuitting)
            {
                m_Instance = FindObjectOfType<GoapPlanner>();
                if (m_Instance == null)
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
        if (m_Instance == null)
        {
            m_Instance = this;
        }
        else if (m_Instance != this)
        {
            Destroy(gameObject);
        }
    }

    #endregion SINGLETON

    public void RegisterGoal(string name, GoapGoal goal)
    {
        m_Goals.Add(name, goal);
    }

    public void UnregisterGoal(string name)
    {
        m_Goals.Remove(name);
    }

    public void RegisterAction(GoapAction action)
    {
        m_Actions.Add(action);
    }

    public void UnregisterAction(GoapAction action)
    {
        m_Actions.Remove(action);
    }

    public GoapGoal GetGoal(string name) 
    {   
        if (m_Goals.ContainsKey(name))
        {
            return m_Goals[name];
        }
        Debug.Log("Cannot find goal: " + name);
        return null;
    }

    public void GeneratePlan(GoapGoal goal)
    {
        GoapNode node = new GoapNode(null);
        BuildPlan(ref node, goal.GetDesiredState());
    }

    public bool BuildPlan(ref GoapNode node, Dictionary<string, bool> conditions)
    {
        foreach(var entry in conditions) //For each condition in the passed conditions
        {
            foreach(var action in m_Actions) //For each action saved in the planner
            {
                foreach (var effect in action.GetEffects()) //For each effect in the action effects
                {
                    //If the condition of the previous action and the effect of the action match, 
                    if (entry.Key == effect.Key && entry.Value == effect.Value) 
                    {
                        Debug.Log("BUILD NODE EFFECT: " + entry.Key);
                        Debug.Log("-------------------------");
                        GoapNode connection = new GoapNode(action);
                        BuildPlan(ref connection, action.GetPreconditions());
                        node.AddNode(connection);
                        Debug.Log("-------------------------");
                    }
                }
            }
            
        }
        if (node.Length() == 0)
        {
            GoapAction action = node.GetAction();
            bool matchesWorldState = true;
            if (action != null)
            {
                foreach (var entry in action.GetPreconditions())
                {
                    matchesWorldState = matchesWorldState && (WorldState.Instance.GetState(entry.Key) == entry.Value);
                }
                if (matchesWorldState)
                {
                    Debug.Log("Action Preconditions match world state");
                }
            }
            return matchesWorldState;
        }

        return true;
    }
}
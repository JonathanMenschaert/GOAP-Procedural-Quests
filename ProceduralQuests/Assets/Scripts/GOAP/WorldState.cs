using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class WorldState : MonoBehaviour
{
    [Serializable]
    public struct State
    {
        public string WorldState;
        public bool Value;

        public State(string state, bool Value)
        {
            this.WorldState = state;   
            this.Value = Value;
        }
    }

    private Dictionary<string, bool> m_States = new Dictionary<string, bool>();

    #region SINGLETON

    public static WorldState m_Instance;
    private static readonly string m_SingleTonInstance = "Singleton_WorldState";

    //Initialize Singleton
    public static WorldState Instance
    {
        get
        {
            if (m_Instance == null && !m_ApplicationQuitting)
            {
                m_Instance = FindObjectOfType<WorldState>();
                if (m_Instance == null)
                {
                    GameObject plannerObject = new GameObject(m_SingleTonInstance);
                    m_Instance = plannerObject.AddComponent<WorldState>();
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
            return;
        }
    }

    #endregion SINGLETON

    public void RegisterState(string condition, bool value)
    {
        m_States.Add(condition, value);
    }

    public void UnregisterState(string condition)
    {
        m_States.Remove(condition);
    }
}

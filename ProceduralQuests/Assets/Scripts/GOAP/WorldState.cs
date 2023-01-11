using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class WorldState : MonoBehaviour
{

    private Dictionary<string, GoapState> m_States;

    #region SINGLETON

    public static WorldState m_Instance;
    private static readonly string m_SingleTonInstance = "Singleton_WorldState";

    //Initialize Singleton
    public static WorldState Instance
    {
        get
        {
            if (m_Instance && !m_ApplicationQuitting)
            {
                m_Instance = FindObjectOfType<WorldState>();
                if (m_Instance)
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
        if (m_Instance)
        {
            m_Instance = this;
        }
        else if (m_Instance != this)
        {
            Destroy(gameObject);
            return;
        }

        m_States = new Dictionary<string, GoapState>();
    }

    #endregion SINGLETON
}

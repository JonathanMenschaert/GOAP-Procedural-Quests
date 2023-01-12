using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Blackboard : MonoBehaviour
{
    #region SINGLETON

    public static Blackboard m_Instance;
    private static readonly string m_SingleTonInstance = "Singleton_Blackboard";
    private Dictionary<string, IDataField> m_Blackboard;

    //Initialize Singleton
    public static Blackboard Instance
    {
        get
        {
            if (m_Instance == null && !m_ApplicationQuitting)
            {
                m_Instance = FindObjectOfType<Blackboard>();
                if (m_Instance == null)
                {
                    GameObject plannerObject = new GameObject(m_SingleTonInstance);
                    m_Instance = plannerObject.AddComponent<Blackboard>();
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
        m_Blackboard = new Dictionary<string, IDataField>();
        
    }

    public bool AddData<T>(string name, T data)
    {
        if (!m_Blackboard.ContainsKey(name))
        {
            m_Blackboard[name] = new DataField<T>(data);
        }
        return false;
    }

    public bool ChangeData<T>(string name, T data) 
    {
        if (!m_Blackboard.ContainsKey(name))
        {
            return false;
        }
        DataField<T> field = (DataField<T>)m_Blackboard[name];

        if (field == null)
        {
            return false;
        }
        field.Value = data;

        return true;
    }

    public bool GetData<T>(string name, ref T data)
    {
        if (!m_Blackboard.ContainsKey(name))
        {
            return false;
        }

        DataField<T> field = (DataField<T>)m_Blackboard[name];
        if (field == null)
        {
            return false;
        }
        data = field.Value;
        return true;
    }

    #endregion SINGLETON
}

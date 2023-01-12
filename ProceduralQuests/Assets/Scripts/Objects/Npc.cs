using System.Collections;
using System.Collections.Generic;
using UnityEditor;
using UnityEngine;

public class Npc : MonoBehaviour
{
    [SerializeField]
    private List<string> m_QuestNames;

    private Player m_Player = null;

    private List<GoapGoal> m_QuestList = new List<GoapGoal>();

    [SerializeField]
    private GameObject m_QuestMarkerTemplate;
    
    private GameObject m_QuestMarker;
    //Start is called before the first frame update

    private void Awake()
    {
        Player player = FindObjectOfType<Player>();
        if (player != null)
        {
            m_Player = player;
        }
    }
    private void Start()
    {
        foreach (string quest in m_QuestNames)
        {
            GoapGoal goal = GoapPlanner.Instance.GetGoal(quest);
            if (goal != null)
            {
                m_QuestList.Add(goal);
                GoapPlanner.Instance.GeneratePlan(goal);
            }
        }
    }

    private void Update()
    {
        bool hasQuest = HasQuest();
        if (hasQuest && m_QuestMarker == null)
        {
            m_QuestMarker = Instantiate(m_QuestMarkerTemplate, transform.position + new Vector3(0.0f, transform.localScale.y * 3.5f, 0.0f) , transform.rotation); ;
        }
        else if (!hasQuest && m_QuestMarker != null) 
        {
            Destroy(m_QuestMarker);
            m_QuestMarker = null;
        }
    }

    private void OnMouseDown()
    {
        if (m_Player != null && m_QuestList.Count > 0)
        {
            m_Player.AddQuest(m_QuestList[0]);
            m_QuestList.RemoveAt(0);
        }
    }

    private bool HasQuest()
    {
        return m_QuestList.Count > 0;
    }
}

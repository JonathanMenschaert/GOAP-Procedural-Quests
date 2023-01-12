using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Player : MonoBehaviour
{

    private List<GoapGoal> m_QuestList = new List<GoapGoal>();
    private List<GoapAction> m_CurrentQuest = new List<GoapAction>();
    private GoapGoal m_CurrentGoal;
    private int m_CurrentIndex;
    // Start is called before the first frame update
    public void AddQuest(GoapGoal goal)
    {
        m_QuestList.Add(goal);
    }

    private int FindBestGoal()
    {
        int bestGoalIdx = m_QuestList.Count;
        if (m_QuestList.Count > 0)
        {
            GoapGoal bestGoal = m_QuestList[0];
            bestGoalIdx = 0;
            for (int idx = 1; idx < m_QuestList.Count; ++idx)
            {
                if (m_QuestList[idx].IsValid() && m_QuestList[idx].GetPriority() > bestGoal.GetPriority())
                {
                    bestGoal = m_QuestList[idx];
                    bestGoalIdx = idx;
                }
            }
        }
        return bestGoalIdx;
    }

    private void Update()
    {
        if (m_CurrentGoal == null)
        {
            int newGoalIdx = FindBestGoal();
            if (newGoalIdx < m_QuestList.Count && m_QuestList.Count != 0)
            {
                if (m_QuestList[newGoalIdx] == null)
                {
                    m_QuestList.RemoveAt(newGoalIdx);
                    return;
                }
                m_CurrentGoal = m_QuestList[0];   
                m_CurrentIndex = newGoalIdx;
                m_CurrentQuest = GoapPlanner.Instance.GeneratePlan(m_CurrentGoal);
            }
        }
        else
        {
            if (!m_CurrentGoal.IsValid())
            {
                m_CurrentGoal = null;
                return;
            }

            if (m_CurrentQuest.Count == 0)
            {
                m_CurrentGoal = null;
                m_QuestList.RemoveAt(m_CurrentIndex);
                return;
            }
            if (m_CurrentQuest[0].Execute())
            {
                m_CurrentQuest.RemoveAt(0);
                Blackboard.Instance.ChangeData("Objective", "Quest Completed!");
            }
        }
    }
}
